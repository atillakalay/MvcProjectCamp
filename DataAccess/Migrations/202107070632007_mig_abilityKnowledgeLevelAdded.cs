namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_abilityKnowledgeLevelAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abilities", "KnowledgeLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abilities", "KnowledgeLevel");
        }
    }
}
