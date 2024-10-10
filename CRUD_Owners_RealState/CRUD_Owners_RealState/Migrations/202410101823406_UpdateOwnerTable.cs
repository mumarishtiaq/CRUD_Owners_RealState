namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOwnerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "EntryTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false, maxLength: 50));
            //AlterColumn("dbo.Owners", "OwnerType", c => c.Int(nullable: false));

            // Step 1: Update existing 'OwnerType' string values to match the enum's integer values
            Sql("UPDATE dbo.Owners SET OwnerType = 0 WHERE OwnerType = 'Normal'");
            Sql("UPDATE dbo.Owners SET OwnerType = 1 WHERE OwnerType = 'Invester'");

            // Step 2: Alter the column to int
            AlterColumn("dbo.Owners", "OwnerType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Owners", "OwnerType", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Owners", "EntryTime");

            // Step 1: Convert integers back to strings
            Sql("UPDATE dbo.Owners SET OwnerType = 'Normal' WHERE OwnerType = 0");
            Sql("UPDATE dbo.Owners SET OwnerType = 'Invester' WHERE OwnerType = 1");

            // Step 2: Revert the column to string
            AlterColumn("dbo.Owners", "OwnerType", c => c.String(nullable: false));
        }
    }
}
