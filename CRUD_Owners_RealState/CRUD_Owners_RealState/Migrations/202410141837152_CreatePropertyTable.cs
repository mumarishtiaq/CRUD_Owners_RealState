namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePropertyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        PlotNo = c.String(nullable: false),
                        PropertyType = c.Int(nullable: false),
                        PropertyStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Properties");
        }
    }
}
