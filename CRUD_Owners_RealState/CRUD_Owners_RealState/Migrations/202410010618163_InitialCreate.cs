namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CNIC = c.String(nullable: false),
                        CellNo = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNo = c.String(),
                        Address = c.String(),
                        ImagePath = c.String(),
                        FingerPrint = c.Binary(),
                        SODOWO = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        OwnerType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Owners");
        }
    }
}
