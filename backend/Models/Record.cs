using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Record
    {
        [Key]
        public string Id { get; set; }
        public string Content { get; set; } 
    }
}
