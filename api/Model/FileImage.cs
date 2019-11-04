using System.Collections;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace api.Model
{
    public class FileImage
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string source { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
    }
}