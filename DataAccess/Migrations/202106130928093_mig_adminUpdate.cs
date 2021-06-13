namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 20));
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "AdminUserNameSalt");
            DropColumn("dbo.Admins", "AdminUserNameHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserNameHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserNameSalt", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            DropColumn("dbo.Admins", "AdminPassword");
        }
    }
}
