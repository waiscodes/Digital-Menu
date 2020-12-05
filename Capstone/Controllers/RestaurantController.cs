using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone.Utilities;

namespace Capstone.Controllers
{
    public class RestaurantController : Controller
    {

        // CREATE
        public string Register(string resName, string resUsername, string email, string password, string resLocation)
        {
            if (UserStr.IsLengthOverLimit(75, resName)) throw new Exception("Restaurant Username cannot be over 75 Characters");
       
            if (UserStr.IsLengthOverLimit(75, resName)) throw new Exception("Restaurant Username cannot be over 75 Characters");

            using (RestaurantContext context = new RestaurantContext())
            {
                if (context.Restaurants.Any(x => x.ResUsername == resUsername))
                {
                    throw new Exception("Restaurant username is taken");
                }

                Restaurant newRestaurant = new Restaurant()
                {
                    ResName = resName,
                    ResUsername = resUsername,
                    Email = email,
                    Password = password,
                    ResLocation = resLocation
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
            Restaurant restaurant;
            using (RestaurantContext context = new RestaurantContext())
            {
                restaurant = context.Restaurants.Where(r => r.ResUsername == username).SingleOrDefault();
            }
            return restaurant;
        }
    }
}
