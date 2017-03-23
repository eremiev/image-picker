namespace ImagePicker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserIDtoPhonetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Phones", "UserID");
            AddForeignKey("dbo.Phones", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Phones", new[] { "UserID" });
            DropColumn("dbo.Phones", "UserID");
        }
    }
}
