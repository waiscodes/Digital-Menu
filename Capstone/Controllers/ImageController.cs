using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class ImageController : Controller
    {
        // CREATE
        public static async Task<string> UploadImage(string name, IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var newFileName = string.Concat(name, fileExtension);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newFileName;
        }
    }
}
