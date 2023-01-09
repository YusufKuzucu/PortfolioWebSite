using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class AdminPhoneNumber
    {
        [Key]
        public int Id { get; set; }
       
        public string PhoneNumber { get; set; }
    }
}
