using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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

        [HttpGet("Login")]
        public ActionResult<string> Login_GET(string email, string password)
        {
            return new RestaurantController().Login(email, password);
        }

        // // // // // // // //  USERS // // // // // // // // 

        [HttpPost("CreateCat")]
        public ActionResult<string> CreateCat_POST(string catName, string username)
        {
            new CategoryController().CreateCategory(catName, username);
            return "Successfully created new category";
        }
    }
}
