using System.IO;
using Microsoft.AspNetCore.Http;

namespace api.Model.parameters
{
    public class Parameters
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}