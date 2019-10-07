namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableGenresBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenresBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameGenre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "GenreBookId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "GenresBooks_Id", c => c.Int());
            CreateIndex("dbo.Books", "GenresBooks_Id");
            AddForeignKey("dbo.Books", "GenresBooks_Id", "dbo.GenresBooks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenresBooks_Id", "dbo.GenresBooks");
            DropIndex("dbo.Books", new[] { "GenresBooks_Id" });
            DropColumn("dbo.Books", "GenresBooks_Id");
            DropColumn("dbo.Books", "GenreBookId");
            DropTable("dbo.GenresBooks");
        }
    }
}
