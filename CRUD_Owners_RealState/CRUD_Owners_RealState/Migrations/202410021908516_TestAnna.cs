namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAnna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Anna", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "Anna");
        }
    }
}
