namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nominees", "Relation", c => c.Int(nullable: false));
            AlterColumn("dbo.Nominees", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "DOB", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Nominees", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Nominees", "Relation", c => c.String(nullable: false));
        }
    }
}
