using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical13MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }     
        public string Name { get; set; }    
        public DateTime Dob { get; set; }
        public int age { get; set; }    
    }

    public class EmployeeContext : DbContext{ 
    
            public EmployeeContext():base("name=MyConnection") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext, 
                Practical13MVC.Migrations.Configuration>());

        }    
        public DbSet<Employee> Employees { get; set;}

    
    
    }
}