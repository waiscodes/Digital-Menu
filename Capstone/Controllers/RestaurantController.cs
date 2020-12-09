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
        /*
        Restaurant Controller with all the methods that interact with the Restaurant table. (Restaurant = user)
            Methods are seperated and ordered by CRUD functionalities (Create, read, update, delete)
         */

        // CREATE
        public string Register(string resName, string resUsername, string email, string password, string resLocation)
        {
            if (string.IsNullOrWhiteSpace(resName)) throw new Exception("Restaurant Name cannot be empty");
            resName = resName.Trim();
            if (UserStr.IsLengthOverLimit(75, resName)) throw new Exception("Restaurant Name cannot exceed 75 Characters");

            if (string.IsNullOrWhiteSpace(resUsername)) throw new Exception("Restaurant Username cannot be empty");
            resUsername = resUsername.Trim().ToLower();
            if (UserStr.IsLengthOverLimit(75, resUsername)) throw new Exception("Restaurant Username cannot exceed 75 Characters");
            if (resUsername.Contains(" ")) throw new Exception("Username cannot contain a space");
            if (UserStr.ContainsSpecialChar(resUsername)) throw new Exception("Username cannot contain special characters");

            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Email cannot be empty");
            email = email.Trim();
            if (UserStr.IsLengthOverLimit(64, email)) throw new Exception("Email cannot exceed 64 Characters");
            if (!UserStr.IsValidEmail(email)) throw new Exception("Please enter a valid email address");

            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password cannot be empty");
            if (UserStr.IsLengthOverLimit(50, password)) throw new Exception("Password cannot exceed 50 Characters");

            if (string.IsNullOrWhiteSpace(resLocation)) throw new Exception("Restaurant Location cannot be empty");
            resLocation = resLocation.Trim();
            if (UserStr.IsLengthOverLimit(75, resLocation)) throw new Exception("Address cannot exceed 75 Characters");

            using (RestaurantContext context = new RestaurantContext())
            {
                if (context.Restaurants.Any(x => x.ResUsername == resUsername)) throw new Exception("Restaurant username is taken");
                if (context.Restaurants.Any(x => x.Email == email)) throw new Exception("An account by that email already exists");

                Restaurant newRestaurant = new Restaurant()
                {
                    // Citation: [1] Microsoft Docs for Regex escape
                    ResName = Regex.Escape(resName),
                    ResUsername = resUsername,
                    Email = email,
                    Password = Regex.Escape(password),
                    ResLocation = Regex.Escape(resLocation)
                };
                context.Restaurants.Add(newRestaurant);
                context.SaveChanges();
            }

            /*
             * 4 Categories are created for user by default. 
             */
            new CategoryController().CreateCategory("Starters", resUsername);
            new CategoryController().CreateCategory("Main Course", resUsername);
            new CategoryController().CreateCategory("Dessert", resUsername);
            new CategoryController().CreateCategory("Drinks", resUsername);

            return resUsername;
        }

        // READ
        public string Login(string email, string password)
        {
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

        /*
         This is a utility method. It is not directly called by the API but it is used by many of the methods that are.
         */
        public static Restaurant GetResByUsername(string username)
        {
            username = username.Trim().ToLower();
            Restaurant restaurant;
            using (RestaurantContext context = new RestaurantContext())
            {
                if (context.Restaurants.Any(r => r.ResUsername == username))
                {
                    restaurant = context.Restaurants.Where(r => r.ResUsername == username).SingleOrDefault();
                }
                else
                {
                    throw new Exception("NOT FOUND: No restaurant by that name");
                }
            }
            return restaurant;
        }

        /* Citations
         * 1 - https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.escape?view=net-5.0
         */
    }
}
