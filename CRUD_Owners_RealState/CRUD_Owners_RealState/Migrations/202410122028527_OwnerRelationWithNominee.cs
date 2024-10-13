namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerRelationWithNominee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nominees",
                c => new
                    {
                        NomineeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CNIC = c.String(nullable: false),
                        Relation = c.String(nullable: false),
                        SODOWO = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        CellNo = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Address = c.String(),
                        ImagePath = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NomineeId)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nominees", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Nominees", new[] { "OwnerId" });
            DropTable("dbo.Nominees");
        }
    }
}
