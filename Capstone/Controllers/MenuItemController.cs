using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.Utilities;
using System.Text.RegularExpressions;

namespace Capstone.Controllers
{
    public class MenuItemController : Controller
    {
        // CREATE
        public async Task<string> CreateMenuItem(string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, string resUsername, IFormFile file)
        {
            name = name.Trim();
            if (UserStr.IsLengthOverLimit(100, name)) throw new Exception("Name cannot exceed 100 characters");

            description = description.Trim();
            if (UserStr.IsLengthOverLimit(1000, description)) throw new Exception("Description cannot exceed 100 characters");

            ingredients = ingredients.Trim();
            if (UserStr.IsLengthOverLimit(1000, ingredients)) throw new Exception("Ingredients cannot exceed 100 characters");


            int redID = RestaurantController.GetResByUsername(resUsername).ID;
            string fileName = await ImageController.UploadImage(name, file);

            using (RestaurantContext context = new RestaurantContext())
            {
                MenuItem newMenuItem = new MenuItem()
                {
                    Name = Regex.Escape(name),
                    Description = Regex.Escape(description),
                    Price = double.Parse(price),
                    WaitTimeMins = int.Parse(waitTimeMins),
                    Ingredients = Regex.Escape(ingredients),
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
            username = username.Trim().ToLower();
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
            name = name.Trim();
            if (UserStr.IsLengthOverLimit(100, name)) throw new Exception("Name cannot exceed 100 characters");

            description = description.Trim();
            if (UserStr.IsLengthOverLimit(1000, description)) throw new Exception("Description cannot exceed 100 characters");

            ingredients = ingredients.Trim();
            if (UserStr.IsLengthOverLimit(1000, ingredients)) throw new Exception("Ingredients cannot exceed 100 characters");

            using (RestaurantContext context = new RestaurantContext())
            {
                MenuItem menuItem = context.MenuItems.Where(m => m.ID == int.Parse(menuID)).SingleOrDefault();
                if (!string.IsNullOrWhiteSpace(name)) menuItem.Name = Regex.Escape(name);
                
                if (file != null)
                {
                    new ImageController(hostEnvironment).DeleteImageByName(menuItem.ImageName);
                    await ImageController.UploadImage(menuItem.Name, file);
                }
                if (!string.IsNullOrWhiteSpace(description)) menuItem.Description = Regex.Escape(description);
                
                if (!string.IsNullOrWhiteSpace(price)) menuItem.Price = double.Parse(price);
                
                if (!string.IsNullOrWhiteSpace(waitTimeMins)) menuItem.WaitTimeMins = int.Parse(waitTimeMins);
                
                if (!string.IsNullOrWhiteSpace(ingredients)) menuItem.Ingredients = Regex.Escape(ingredients);
                
                if (!string.IsNullOrWhiteSpace(calories)) menuItem.Calories = int.Parse(calories);
                
                if (!string.IsNullOrWhiteSpace(halal)) menuItem.Halal = bool.Parse(halal);
                
                if (!string.IsNullOrWhiteSpace(catID)) menuItem.CategoryID = int.Parse(catID);
                
                context.SaveChanges();
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