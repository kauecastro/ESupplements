namespace Supplements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstThings : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clients", new[] { "UserAccount_id" });
            CreateIndex("dbo.Clients", "UserAccount_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clients", new[] { "UserAccount_Id" });
            CreateIndex("dbo.Clients", "UserAccount_id");
        }
    }
}
