namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationOwnerWithProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Properties", "OwnerId");
            AddForeignKey("dbo.Properties", "OwnerId", "dbo.Owners", "OwnerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "OwnerId" });
            DropColumn("dbo.Properties", "OwnerId");
        }
    }
}
