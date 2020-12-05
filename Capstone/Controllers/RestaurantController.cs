using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone.Utilities;
using System.Text.RegularExpressions;

namespace Capstone.Controllers
{
    public class RestaurantController : Controller
    {

        // CREATE
        public string Register(string resName, string resUsername, string email, string password, string resLocation)
        {
            resName = resName.Trim();
            if (UserStr.IsLengthOverLimit(75, resName)) throw new Exception("Restaurant Name cannot exceed excede 75 Characters");

            resUsername = resUsername.Trim().ToLower();
            if (UserStr.IsLengthOverLimit(75, resUsername)) throw new Exception("Restaurant Username cannot exceed 75 Characters");
            if (resUsername.Contains(" ")) throw new Exception("Username cannot contain a space");
            if (UserStr.ContainsSpecialChar(resUsername)) throw new Exception("Username cannot contain special characters");

            email = email.Trim();
            if (UserStr.IsLengthOverLimit(64, email)) throw new Exception("Email cannot exceed 64 Characters");
            if (!UserStr.IsValidEmail(email)) throw new Exception("Please enter a valid email address");

            if (UserStr.IsLengthOverLimit(50, password)) throw new Exception("Password cannot exceed 50 Characters");

            resLocation = resLocation.Trim();
            if (UserStr.IsLengthOverLimit(75, resLocation)) throw new Exception("Address cannot exceed 75 Characters");

            using (RestaurantContext context = new RestaurantContext())
            {
                if (context.Restaurants.Any(x => x.ResUsername == resUsername)) throw new Exception("Restaurant username is taken");

                Restaurant newRestaurant = new Restaurant()
                {
                    ResName = Regex.Escape(resName),
                    ResUsername = resUsername,
                    Email = email,
                    Password = Regex.Escape(password),
                    ResLocation = Regex.Escape(resLocation)
                };
                context.Restaurants.Add(newRestaurant);
                context.SaveChanges();
            }
            new CategoryController().CreateCategory("Starters", resUsername);
            new CategoryController().CreateCategory("Main Course", resUsername);
            new CategoryController().CreateCategory("Dessert", resUsername);
            new CategoryController().CreateCategory("Drinks", resUsername);

            return resUsername;
        }

        // READ
        public string Login(string email, string password)
        {
            /* Email: Validate, trim, to lower
             * Password: Escape
             */

            email = email.Trim().ToLower();
            if (!UserStr.IsValidEmail(email)) throw new Exception("Please enter a valid Email address");
            password = Regex.Escape(password);

            string username;
            using (RestaurantContext context = new RestaurantContext())
            {
                if (!context.Restaurants.Any(x => x.Email == email))
                {
                    throw new Exception("There is no account under this email");
                }
                else 
                {
                    Restaurant account = context.Restaurants.Where(r => r.Email == email).SingleOrDefault();
                    if (account.Password == password)
                    {
                        username = account.ResUsername;
                    }
                    else
                    {
                        throw new Exception("Password is incorrect");
                    }
                }
            }
            return username;
        }

        public static Restaurant GetResByUsername(string username)
        {
            /* Username: ToLower
             */
            Restaurant restaurant;
            using (RestaurantContext context = new RestaurantContext())
            {
                restaurant = context.Restaurants.Where(r => r.ResUsername == username).SingleOrDefault();
            }
            return restaurant;
        }
    }
}
