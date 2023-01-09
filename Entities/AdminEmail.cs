using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class AdminEmail
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
