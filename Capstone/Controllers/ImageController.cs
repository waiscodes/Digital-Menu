﻿using System;
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
        /*
         Images controller with all the image methods. Just create and delete imagename is in the database and create/delete act as edit. 
         */
        // Citation: [1] IWebHostEnvironment
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment hostEnvironment)
        {
            _webHostEnvironment = hostEnvironment;
        }

        // CREATE
        public static async Task<string> UploadImage(string name, IFormFile file)
        {
            if (name.Length > 15) name = name.Substring(0, 15);

            name = name.Replace(" ", "-");

            // Citation: [2] Image upload
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

        /* Citations
         * 1 - IWebHost https://github.com/CodAffection/React-Asp.Net-Core-API---Image-Upload-Retrieve-Update-and-Delete-/blob/master/EmployeeRegisterAPI/EmployeeRegisterAPI/Controllers/EmployeeController.cs
         * 2- Image Upload https://github.com/CodAffection/React-Asp.Net-Core-API---Image-Upload-Retrieve-Update-and-Delete-/blob/master/EmployeeRegisterAPI/EmployeeRegisterAPI/Controllers/EmployeeController.cs And lots of help from instructor Tammy V
         */
    }
}