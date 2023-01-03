using Microsoft.AspNetCore.Http;
using System;
using System.Reflection.PortableExecutable;

namespace PortfolioPresentation.Models
{
    public class AddImage
    {
        public int ImageId { get; set; }
        public IFormFile ImagePath { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
    }
}
