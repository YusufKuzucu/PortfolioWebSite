using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
