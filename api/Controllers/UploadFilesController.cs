using Microsoft.AspNetCore.Mvc;
using api.Model.parameters;
using System.IO;
using api.Model;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromForm]Parameters model)
        {
            // Getting Name
            string name = model.Name;
            // Getting Image
            var image = model.Image;
            // Saving Image on Server
            if (image.Length > 0)
            {
                var File = ImageToByteArray(image);
                var imageByte = new FileImage{
                    File = File,
                    Name = name
                };
            }
            return Ok(new { status = true, message = "Student Posted Successfully" });
        }

        private byte[] ImageToByteArray(IFormFile file)
        {
            byte[] bytes;
            string fileName = file.FileName;

             using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string contentAsString = reader.ReadToEnd();
                bytes = new byte[contentAsString.Length * sizeof(char)];
                System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, bytes, 0, bytes.Length);
            }
            return bytes;
        }
    }
}
