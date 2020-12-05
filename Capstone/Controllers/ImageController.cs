using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment hostEnvironment)
        {
            _webHostEnvironment = hostEnvironment;
        }

        // CREATE
        public static async Task<string> UploadImage(string name, IFormFile file)
        {
            /* TODO: take in ID as well add ID to name after putting dashes in spaces for name. 
             */

            var fileExtension = Path.GetExtension(file.FileName);
            var newFileName = string.Concat(name, fileExtension);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newFileName;
        }

        // DELETE
        public void DeleteImageByName(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}