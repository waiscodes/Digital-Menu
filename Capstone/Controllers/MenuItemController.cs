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

        public void CreateMenuValidator(string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, string resUsername, IFormFile file)
        {
            // INT VALIDATION
            double parsedPrice;
            if (!double.TryParse(price, out parsedPrice)) throw new Exception("Price must be a number");
            if (!UserInt.IsPositiveNumber(parsedPrice)) throw new Exception("Price can't be under $0");

            int parsedWaitTime;
            if (!int.TryParse(waitTimeMins, out parsedWaitTime)) throw new Exception("Price must be a number");
            if (!UserInt.IsPositiveNumber(parsedWaitTime)) throw new Exception("Wait time can't be under 0 minutes");

            int parsedCalories;
            if (!int.TryParse(calories, out parsedCalories)) throw new Exception("Calories must be a number");
            if (!UserInt.IsPositiveNumber(parsedCalories)) throw new Exception("Calories can't be under 0 Calories. You wish");

            int parsedCatID;
            if (!int.TryParse(catID, out parsedCatID)) throw new Exception("Category ID must be a Number");

            //BOOL VALIDATION
            bool parsedHalal;
            halal = halal.ToLower().Trim();
            if (!bool.TryParse(halal, out parsedHalal)) throw new Exception("Halal must be either true or false");

            // STRING VALIDATION
            name = name.Trim();
            if (UserStr.IsLengthOverLimit(100, name)) throw new Exception("Name cannot exceed 100 characters");

            description = description.Trim();
            if (UserStr.IsLengthOverLimit(1000, description)) throw new Exception("Description cannot exceed 100 characters");

            ingredients = ingredients.Trim();
            if (UserStr.IsLengthOverLimit(1000, ingredients)) throw new Exception("Ingredients cannot exceed 100 characters");

            RestaurantController.GetResByUsername(resUsername);

            CreateMenuItem(name, description, parsedPrice, parsedWaitTime, ingredients, parsedCalories, parsedHalal, parsedCatID, resUsername, file);
        }

        public async void CreateMenuItem(string name, string description, double parsedPrice, int parsedWaitTime, string ingredients, int parsedCalories, bool parsedHalal, int parsedCatID, string resUsername, IFormFile file)
        {

            int redID = RestaurantController.GetResByUsername(resUsername).ID;

            string fileName = await ImageController.UploadImage(name, file);

            using (RestaurantContext context = new RestaurantContext())
            {
                MenuItem newMenuItem = new MenuItem()
                {
                    Name = Regex.Escape(name),
                    Description = Regex.Escape(description),
                    Price = parsedPrice,
                    WaitTimeMins = parsedWaitTime,
                    Ingredients = Regex.Escape(ingredients),
                    Calories = parsedCalories,
                    Halal = parsedHalal,
                    CategoryID = parsedCatID,
                    RestaurantID = redID,
                    ImageName = fileName
                };
                context.MenuItems.Add(newMenuItem);
                context.SaveChanges();
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
            int parsedID;
            if (!int.TryParse(id, out parsedID)) throw new Exception("ID must be a number");

            using (RestaurantContext context = new RestaurantContext())
            {
               return context.MenuItems
                    .Where(m => m.ID == parsedID)
                    .SingleOrDefault();
            }
        }

        // UPDATE
        public async Task<MenuItem> UpdateMenuItem(string menuID, string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, IFormFile file, IWebHostEnvironment hostEnvironment)
        {

            // INT VALIDATION
            int parsedMenuID;
            if (!int.TryParse(menuID, out parsedMenuID)) throw new Exception("Menu ID must be a number");

            double parsedPrice;
            if (!double.TryParse(price, out parsedPrice)) throw new Exception("Price must be a number");
            if (!UserInt.IsPositiveNumber(parsedPrice)) throw new Exception("Price can't be under $0");

            int parsedWaitTime;
            if (!int.TryParse(waitTimeMins, out parsedWaitTime)) throw new Exception("Price must be a number");
            if (!UserInt.IsPositiveNumber(parsedWaitTime)) throw new Exception("Wait time can't be under 0 minutes");

            int parsedCalories;
            if (!int.TryParse(calories, out parsedCalories)) throw new Exception("Calories must be a number");
            if (!UserInt.IsPositiveNumber(parsedCalories)) throw new Exception("Calories can't be under 0 Calories. You wish");

            int parsedCatID;
            if (!int.TryParse(catID, out parsedCatID)) throw new Exception("Category ID must be a Number");

            //BOOL VALIDATION
            bool parsedHalal;
            halal = halal.ToLower().Trim();
            if (!bool.TryParse(halal, out parsedHalal)) throw new Exception("Halal must be either true or false");

            // STRING VALIDATION AND SANITIZATION
            name = name.Trim();
            if (UserStr.IsLengthOverLimit(100, name)) throw new Exception("Name cannot exceed 100 characters");

            description = description.Trim();
            if (UserStr.IsLengthOverLimit(1000, description)) throw new Exception("Description cannot exceed 100 characters");

            ingredients = ingredients.Trim();
            if (UserStr.IsLengthOverLimit(1000, ingredients)) throw new Exception("Ingredients cannot exceed 100 characters");

            using (RestaurantContext context = new RestaurantContext())
            {
                MenuItem menuItem = context.MenuItems.Where(m => m.ID == parsedMenuID).SingleOrDefault();
                if (!string.IsNullOrWhiteSpace(name)) menuItem.Name = Regex.Escape(name);
                
                if (file != null)
                {
                    new ImageController(hostEnvironment).DeleteImageByName(menuItem.ImageName);
                    await ImageController.UploadImage(menuItem.Name, file);
                }
                if (!string.IsNullOrWhiteSpace(description)) menuItem.Description = Regex.Escape(description);
                
                if (!string.IsNullOrWhiteSpace(price)) menuItem.Price = parsedPrice;
                
                if (!string.IsNullOrWhiteSpace(waitTimeMins)) menuItem.WaitTimeMins = parsedWaitTime;
                
                if (!string.IsNullOrWhiteSpace(ingredients)) menuItem.Ingredients = Regex.Escape(ingredients);
                
                if (!string.IsNullOrWhiteSpace(calories)) menuItem.Calories = parsedCalories;
                
                if (!string.IsNullOrWhiteSpace(halal)) menuItem.Halal = parsedHalal;
                
                if (!string.IsNullOrWhiteSpace(catID)) menuItem.CategoryID = parsedCatID;
                
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