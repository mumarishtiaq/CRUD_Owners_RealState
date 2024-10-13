namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEntryTimeField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Owners", "EntryTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "EntryTime", c => c.DateTime(nullable: false));
        }
    }
}
