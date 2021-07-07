namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "CreatedDate");
        }
    }
}
