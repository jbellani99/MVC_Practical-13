using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical13Test2.Models
{
    public class ContextClass : DbContext
    {

        public ContextClass() : base("name=Myconnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextClass,
            //Practical13Test2.Migrations.Configuration>());

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Designations> designations { get; set; }



    }
}