namespace Supplements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersUpdates2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "StatusOrder_id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_id" });
            CreateIndex("dbo.Orders", "StatusOrder_Id");
            CreateIndex("dbo.OrderProducts", "Order_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "StatusOrder_Id" });
            CreateIndex("dbo.OrderProducts", "Order_id");
            CreateIndex("dbo.Orders", "StatusOrder_id");
        }
    }
}
