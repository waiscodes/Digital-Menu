using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CategoryController : Controller
    {
        // CREATE
        public void CreateCategory(string catName, string username)
        {
            Restaurant theUser = RestaurantController.GetResByUsername(username);
            using (RestaurantContext context = new RestaurantContext())
            {
                Category newCategory = new Category()
                {
                    Name = catName,
                    RestaurantID = theUser.ID
                };
                context.Add(newCategory);
                context.SaveChanges();
            }
        }

        // READ
        public List<Category> ListCategories(string username)
        {
            if (String.IsNullOrWhiteSpace(username)) throw new Exception("Username cannot be null");

            username = username.Trim().ToLower();
            List<Category> result;
            Restaurant restaurant = RestaurantController.GetResByUsername(username);
            using (RestaurantContext context = new RestaurantContext())
            {
                result = context.Categories.Where(m => m.RestaurantID == restaurant.ID).ToList();
            }
            return result;
        }
    }
}
