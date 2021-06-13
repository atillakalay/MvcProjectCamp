namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_myAbout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyAbouts",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Skill1 = c.String(maxLength: 100),
                        Skill2 = c.String(maxLength: 100),
                        Skill3 = c.String(maxLength: 100),
                        Skill4 = c.String(maxLength: 100),
                        Rate1 = c.Int(nullable: false),
                        Rate2 = c.Int(nullable: false),
                        Rate3 = c.Int(nullable: false),
                        Rate4 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyAbouts");
        }
    }
}
