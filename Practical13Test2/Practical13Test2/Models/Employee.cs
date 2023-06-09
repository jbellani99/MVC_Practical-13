using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Practical13Test2.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string First_Name{ get; set; }
        
        public string Middle_name { get; set; }

        [Required]
        public string Last_Name { get; set;}
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }   
        [Required]
        public int Mobile_Number { get; set;}

        [MaxLength(100)]
        public string Address { get; set;}  
        [Required]
        public int Salary { get; set; }

       
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designations Designations { get; set; }
    
    }
}