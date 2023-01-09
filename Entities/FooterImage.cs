using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class FooterImage
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
