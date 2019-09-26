namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Books_Id", "dbo.Books");
            DropIndex("dbo.Genres", new[] { "Books_Id" });
            AlterColumn("dbo.Authors", "FirstName", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Authors", "LastName", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Users", "FIO", c => c.String());
            DropColumn("dbo.Books", "Image");
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false),
                        Books_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Image", c => c.Binary());
            AlterColumn("dbo.Users", "FIO", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            CreateIndex("dbo.Genres", "Books_Id");
            AddForeignKey("dbo.Genres", "Books_Id", "dbo.Books", "Id");
        }
    }
}
