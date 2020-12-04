using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class MenuItemController : Controller
    {
        // CREATE
        public async Task<string> CreateMenuItem(string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, string resUsername, IFormFile file)
        {
            int redID = RestaurantController.GetResByUsername(resUsername).ID;
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
                    RestaurantID = redID,
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
        public async Task<MenuItem> UpdateMenuItem(string menuID, string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, IFormFile file, IWebHostEnvironment hostEnvironment)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                MenuItem menuItem = GetMenuItemByID(menuID);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    menuItem.Name = name;
                }
                if (file != null)
                {
                    new ImageController(hostEnvironment).DeleteImageByName(menuItem.ImageName);
                    await ImageController.UploadImage(menuItem.Name, file);
                }
                if (!string.IsNullOrWhiteSpace(description))
                {
                    menuItem.Description = description;
                }
                if (!string.IsNullOrWhiteSpace(price))
                {
                    menuItem.Price = double.Parse(price);
                }
                if (!string.IsNullOrWhiteSpace(waitTimeMins))
                {
                    menuItem.WaitTimeMins = int.Parse(waitTimeMins);
                }
                if (!string.IsNullOrWhiteSpace(ingredients))
                {
                    menuItem.Ingredients = ingredients;
                }
                if (!string.IsNullOrWhiteSpace(calories))
                {
                    menuItem.Calories = int.Parse(calories);
                }
                if (!string.IsNullOrWhiteSpace(halal))
                {
                    menuItem.Halal = bool.Parse(halal);
                }
                if (!string.IsNullOrWhiteSpace(catID))
                {
                    menuItem.CategoryID = int.Parse(catID);
                }
            }
            return new MenuItem();
        }

        // DELETE
        public void DeleteMenuItem(string id, IWebHostEnvironment hostEnvironment)
        {
            MenuItem menuItem = GetMenuItemByID(id);
            new ImageController(hostEnvironment)
                .DeleteImageByName(menuItem.ImageName);

            using (RestaurantContext context = new RestaurantContext())
            {
                context.MenuItems.Remove(menuItem);
                context.SaveChanges();
            }
        }
    }
}