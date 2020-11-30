﻿using System;
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

        // READ
        public List<MenuItem> ListMenuItems(string username)
        {
            List<MenuItem> menuList;
            Restaurant restaurant = RestaurantController.GetResByUsername(username);
            using (RestaurantContext context = new RestaurantContext())
            {
                menuList = context.MenuItems.Where(m => m.RestaurantID == restaurant.ID).ToList();
            }
            return menuList;
        }

        public MenuItem GetMenuItemByID(string id)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.MenuItems
                    .Where(m => m.ID == int.Parse(id))
                    .SingleOrDefault();
            }
        }

        // UPDATE
    }
}