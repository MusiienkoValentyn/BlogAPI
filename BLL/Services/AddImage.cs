using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class AddImage
    {
        public static async Task UploadFile(Stream stream, string name)
        {
            string path = Environment.CurrentDirectory + "\\Images\\";
            bool exists = Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }
            var fullPath = Path.Combine(path, name);
            using (FileStream file = new FileStream(fullPath, FileMode.Create))
            {
                await stream.CopyToAsync(file);
            }
        }
    }


    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
