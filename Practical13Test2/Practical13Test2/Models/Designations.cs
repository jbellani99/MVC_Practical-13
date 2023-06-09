using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical13Test2.Models
{
    public class Designations
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Designation { get; set; }    
        
        public ICollection<Employee> employees { get; set; }

    }
}