namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImageData", c => c.Binary());
            AddColumn("dbo.Books", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImageMimeType");
            DropColumn("dbo.Books", "ImageData");
        }
    }
}
