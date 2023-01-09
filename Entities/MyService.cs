using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class MyService
    {
        [Key]
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceIcon { get; set; }
    }
}
