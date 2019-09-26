namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAndEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdersBooks", "CurentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrdersBooks", "Deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrdersBooks", "ActualReturnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "EmailUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "EmailUser");
            DropColumn("dbo.OrdersBooks", "ActualReturnDate");
            DropColumn("dbo.OrdersBooks", "Deadline");
            DropColumn("dbo.OrdersBooks", "CurentDate");
        }
    }
}
