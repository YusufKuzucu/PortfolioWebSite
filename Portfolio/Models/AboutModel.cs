using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class AboutModel
    {
        public int Id { get; set; }
        public string MyAboutDescription { get; set; }

        public string Title { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
