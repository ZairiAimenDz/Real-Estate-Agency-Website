using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REstate.Services
{
    public interface IImageService
    {
        string UploadImage(IFormFile file);
        void ReplaceImage(IFormFile file, string existingfile);
    }
    public class ImageService : IImageService
    {
        public void ReplaceImage(IFormFile file, string existingfile)
        {
        }

        public string UploadImage(IFormFile file)
        {
            return "";
        }
    }
}
