using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class RestaurantController : Controller
    {

        // CREATE
        public string Register(string resName, string resUsername, string email, string password, string resLocation)
        {
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

            return "Successfully added restaurant";
        }
    }
}
