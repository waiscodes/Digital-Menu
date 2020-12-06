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
            try
            {
                return new RestaurantController().Login(email, password);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // // // // // // // //  CATEGORIES // // // // // // // // 
        [HttpGet("ListCat")]
        public ActionResult<List<Category>> ListCat_GET(string username)
        {
            try
            {
                return new CategoryController().ListCategories(username);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // // // // // // // //  MENU ITEMS // // // // // // // //

        [HttpPost("CreateMenu")]
        public ActionResult<String> CreateMenu_POST(string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, string resUsername, IFormFile file)
        {
            try
            {
                new MenuItemController().CreateMenuItem(name, description, price, waitTimeMins, ingredients, calories, halal, catID, resUsername, file);
                return "Successfully added";
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListMenu")]
        public ActionResult<IEnumerable<MenuItem>> ListMenu_GET(string username)
        {
            try
            {
                return new MenuItemController().ListMenuItems(username);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("GetMenuItem")]
        public ActionResult<MenuItem> GetMenuItem_GET(string id)
        {
            try
            {
                return new MenuItemController().GetMenuItemByID(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("ImagePath")]
        public ActionResult<string> GetImagePath_GET()
        {
            return string.Format("{0}://{1}{2}/Images/", Request.Scheme, Request.Host, Request.PathBase);
        }

        [HttpPut("UpdateMenu")]
        public ActionResult<Task<MenuItem>> UpdateMenu_PUT(string menuID, string name, string description, string price, string waitTimeMins, string ingredients, string calories, string halal, string catID, IFormFile file)
        {
            try
            {
                return new MenuItemController().UpdateMenuItem(menuID, name, description, price, waitTimeMins, ingredients, calories, halal, catID, file, _webHostEnvironment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteMenu")]
        public ActionResult<string> DeleteMenu_DELETE(string id)
        {
            try
            {
                new MenuItemController().DeleteMenuItem(id, _webHostEnvironment);
                return "successfully deleted";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}