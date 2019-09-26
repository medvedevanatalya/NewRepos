namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableOrdersBooks : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.BooksAndUsers", "Books_Id", "dbo.Books");
            //DropForeignKey("dbo.BooksAndUsers", "Users_Id", "dbo.Users");
            //DropIndex("dbo.BooksAndUsers", new[] { "Books_Id" });
            //DropIndex("dbo.BooksAndUsers", new[] { "Users_Id" });
            CreateTable(
                "dbo.OrdersBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        BookId = c.Int(),
                        Books_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Books_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Books_Id)
                .Index(t => t.Users_Id);
            
            //DropTable("dbo.BooksAndUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BooksAndUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        IdBook = c.Int(),
                        Books_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.OrdersBooks", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.OrdersBooks", "Books_Id", "dbo.Books");
            DropIndex("dbo.OrdersBooks", new[] { "Users_Id" });
            DropIndex("dbo.OrdersBooks", new[] { "Books_Id" });
            DropTable("dbo.OrdersBooks");
            CreateIndex("dbo.BooksAndUsers", "Users_Id");
            CreateIndex("dbo.BooksAndUsers", "Books_Id");
            AddForeignKey("dbo.BooksAndUsers", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.BooksAndUsers", "Books_Id", "dbo.Books", "Id");
        }
    }
}
