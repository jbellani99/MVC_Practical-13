namespace Practical13Test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigrationMinorChnagesV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Address", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Address", c => c.String());
        }
    }
}
