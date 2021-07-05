namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminStatusAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminStatus");
        }
    }
}
