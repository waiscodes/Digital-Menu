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
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ValuesController(IWebHostEnvironment hostEnvironment)
        {
            _webHostEnvironment = hostEnvironment;
        }

        // // // // // // // //  USERS // // // // // // // // 

        [HttpPost("Register")]
        public ActionResult<string> RegisterRes_POST(string resName, string resUsername, string email, string password, string resLocation)
        {
            try
            {
                return new RestaurantController().Register(resName, resUsername, email, password, resLocation);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("Login")]
        public ActionResult<string> Login_GET(string email, string password)
        {
            return new RestaurantController().Login(email, password);
        }

        // // // // // // // //  CATEGORIES // // // // // // // // 

        [HttpPost("CreateCat")]
        public ActionResult<string> CreateCat_POST(string catName, string username)
        {
            new CategoryController().CreateCategory(catName, username);
            return "Successfully created new category";
        }

        [HttpGet("ListCat")]
        public ActionResult<List<Category>> ListCat_GET(string username)
        {
            return new CategoryController().ListCategories(username);
        }

        // // // // // // // //  MENU ITEMS // // // // // // // //

        [HttpPost("CreateMenu")]
        public ActionResult<Task<string>> CreateMenu_POST(string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, string resUsername, IFormFile file)
        {
            return new MenuItemController().CreateMenuItem(name, description, price, waitTimeMins, ingredients, calories, halal, catID, resUsername, file);
        }

        [HttpGet("ListMenu")]
        public ActionResult<IEnumerable<MenuItem>> ListMenu_GET(string username)
        {
            return new MenuItemController().ListMenuItems(username);
        }

        [HttpGet("GetMenuItem")]
        public ActionResult<MenuItem> GetMenuItem_GET(string id)
        {
            return new MenuItemController().GetMenuItemByID(id);
        }

        [HttpGet("ImagePath")]
        public ActionResult<string> GetImagePath_GET()
        {
            return string.Format("{0}://{1}{2}/Images/", Request.Scheme, Request.Host, Request.PathBase);
        }

        [HttpPut("UpdateMenu")]
        public ActionResult<Task<MenuItem>> UpdateMenu_PUT(string menuID, string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, IFormFile file)
        {
            return new MenuItemController().UpdateMenuItem(menuID, name, description, price, waitTimeMins, ingredients, calories, halal, catID, file, _webHostEnvironment);
        }

        [HttpPatch("UpdateMenuImage")]
        public async void UpdateMenuImage_PATCH(string id, IFormFile file)
        {
            MenuItem menuItem = new MenuItemController().GetMenuItemByID(id);

            new ImageController(_webHostEnvironment).DeleteImageByName(menuItem.ImageName);
            await ImageController.UploadImage(menuItem.Name, file);
        }

        [HttpDelete("DeleteMenu")]
        public ActionResult<string> DeleteMenu_DELETE(string id)
        {
            new MenuItemController().DeleteMenuItem(id, _webHostEnvironment);
            return "successfully deleted";
        }
    }
}