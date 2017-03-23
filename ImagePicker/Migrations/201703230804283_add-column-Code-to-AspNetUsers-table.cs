namespace ImagePicker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnCodetoAspNetUserstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Code");
        }
    }
}
