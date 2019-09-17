namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableGenreAddImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false),
                        Books_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Books_Id)
                .Index(t => t.Books_Id);
            
            AddColumn("dbo.Books", "Image", c => c.Binary());
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Users", "FIO", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Books_Id", "dbo.Books");
            DropIndex("dbo.Genres", new[] { "Books_Id" });
            AlterColumn("dbo.Users", "FIO", c => c.String());
            AlterColumn("dbo.Authors", "LastName", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Books", "Image");
            DropTable("dbo.Genres");
        }
    }
}
