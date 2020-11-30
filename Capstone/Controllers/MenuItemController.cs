using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class MenuItemController : Controller
    {
        // CREATE
        public async Task<string> CreateMenuItem(string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, string resID, IFormFile file)
        {
            string fileName = await ImageController.UploadImage(name, file);

            using (RestaurantContext context = new RestaurantContext())
            {
                MenuItem newMenuItem = new MenuItem()
                {
                    Name = name,
                    Description = description,
                    Price = double.Parse(price),
                    WaitTimeMins = int.Parse(waitTimeMins),
                    Ingredients = ingredients,
                    Calories = int.Parse(calories),
                    Halal = bool.Parse(halal),
                    CategoryID = int.Parse(catID),
                    RestaurantID = int.Parse(resID),
                    ImageName = fileName
                };
                context.MenuItems.Add(newMenuItem);
                context.SaveChanges();

                return "Sucess";
            }
        }
    }
}