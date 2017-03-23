namespace ImagePicker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneandImagetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Base64 = c.String(),
                        PhoneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Phones", t => t.PhoneID, cascadeDelete: true)
                .Index(t => t.PhoneID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UniqueID = c.String(),
                        NameHolder = c.String(),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PhoneID", "dbo.Phones");
            DropIndex("dbo.Images", new[] { "PhoneID" });
            DropTable("dbo.Phones");
            DropTable("dbo.Images");
        }
    }
}
