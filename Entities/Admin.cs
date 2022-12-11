using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
