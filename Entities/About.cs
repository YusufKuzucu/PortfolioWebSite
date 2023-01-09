using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string MyAboutDescription { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }
}
