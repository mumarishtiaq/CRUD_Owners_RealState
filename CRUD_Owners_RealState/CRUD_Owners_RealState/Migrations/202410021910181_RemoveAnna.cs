namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnna : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Owners", "Anna");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "Anna", c => c.String());
        }
    }
}
