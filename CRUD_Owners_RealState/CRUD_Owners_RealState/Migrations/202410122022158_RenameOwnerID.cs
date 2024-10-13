namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameOwnerID : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Owners");
            //AddColumn("dbo.Owners", "OwnerId", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Owners", "OwnerId");
            //DropColumn("dbo.Owners", "ID");

            RenameColumn("dbo.Owners", "ID", "OwnerId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Owners", "ID", c => c.Int(nullable: false, identity: true));
            //DropPrimaryKey("dbo.Owners");
            //DropColumn("dbo.Owners", "OwnerId");
            //AddPrimaryKey("dbo.Owners", "ID");

            RenameColumn("dbo.Owners", "OwnerId", "ID");
        }
    }
}
