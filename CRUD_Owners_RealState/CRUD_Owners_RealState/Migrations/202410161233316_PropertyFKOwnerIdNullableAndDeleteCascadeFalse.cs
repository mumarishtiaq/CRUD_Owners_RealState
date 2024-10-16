namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyFKOwnerIdNullableAndDeleteCascadeFalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Properties", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "OwnerId" });
            AlterColumn("dbo.Properties", "OwnerId", c => c.Int());
            CreateIndex("dbo.Properties", "OwnerId");
            AddForeignKey("dbo.Properties", "OwnerId", "dbo.Owners", "OwnerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "OwnerId" });
            AlterColumn("dbo.Properties", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Properties", "OwnerId");
            AddForeignKey("dbo.Properties", "OwnerId", "dbo.Owners", "OwnerId", cascadeDelete: true);
        }
    }
}
