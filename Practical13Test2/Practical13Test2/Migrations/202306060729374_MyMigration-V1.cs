namespace Practical13Test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigrationV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false),
                        Middle_name = c.String(),
                        Last_Name = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Mobile_Number = c.Int(nullable: false),
                        Address = c.String(),
                        Salary = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
