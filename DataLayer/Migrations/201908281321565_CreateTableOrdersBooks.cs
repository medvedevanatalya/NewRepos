namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableOrdersBooks : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersBooks", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.OrdersBooks", "Books_Id", "dbo.Books");
            DropIndex("dbo.OrdersBooks", new[] { "Users_Id" });
            DropIndex("dbo.OrdersBooks", new[] { "Books_Id" });
            DropTable("dbo.OrdersBooks");      
        }
    }
}
