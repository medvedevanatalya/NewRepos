namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableUsersAndBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersAndBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .ForeignKey("dbo.Books", t => t.IdBook)
                .Index(t => t.IdUser)
                .Index(t => t.IdBook);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersAndBooks", "IdBook", "dbo.Books");
            DropForeignKey("dbo.UsersAndBooks", "IdUser", "dbo.Users");
            DropIndex("dbo.UsersAndBooks", new[] { "IdBook" });
            DropIndex("dbo.UsersAndBooks", new[] { "IdUser" });
            DropTable("dbo.UsersAndBooks");
        }
    }
}
