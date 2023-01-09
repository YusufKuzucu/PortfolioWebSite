using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class AdminAddress
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
 
    }
}
