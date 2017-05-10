namespace Supplements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusOrders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Orders", "Client_Id", c => c.Int());
            AddColumn("dbo.Orders", "StatusOrder_id", c => c.Int());
            CreateIndex("dbo.Orders", "Client_Id");
            CreateIndex("dbo.Orders", "StatusOrder_id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Orders", "StatusOrder_id", "dbo.StatusOrders", "id");
            DropColumn("dbo.Orders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Status", c => c.String());
            DropForeignKey("dbo.Orders", "StatusOrder_id", "dbo.StatusOrders");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "StatusOrder_id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropColumn("dbo.Orders", "StatusOrder_id");
            DropColumn("dbo.Orders", "Client_Id");
            DropTable("dbo.StatusOrders");
        }
    }
}
