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
        // READ
        public List<Category> ListCategories(string username)
        {
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
