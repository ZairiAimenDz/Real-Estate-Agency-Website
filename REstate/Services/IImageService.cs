
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace REstate.Services
{
    public interface IImageService
    {
        string UploadImage(IFormFile file);
        Task<string> UploadImage(IBrowserFile bfile);
        void ReplaceImage(IFormFile file, string existingfile);
        bool DeleteImage(string file);
    }
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteImage(string file)
        {                
            string uploadsfile = Path.Combine(webHostEnvironment.WebRootPath, file);
            try { 
                if(File.Exists(uploadsfile))
                    File.Delete(uploadsfile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ReplaceImage(IFormFile file, string existingfile)
        {
            if (file.Name is not null)
            {
                string filePath = Path.Combine(webHostEnvironment.WebRootPath, existingfile);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
        }

        public string UploadImage(IFormFile file)
        {
            string uniqueFileName = null;

            if (file is not null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return "images/" + uniqueFileName;
        }
        
        public async Task<string> UploadImage(IBrowserFile bfile)
        {
            string uniqueFileName = null;
            var file = bfile.OpenReadStream(maxAllowedSize:4096000);

            if (file is not null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + bfile.Name;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return "images/" + uniqueFileName;
        }
    }
}
