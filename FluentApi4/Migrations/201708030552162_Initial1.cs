namespace FluentApi4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MCustomer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.MOrder",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.MCustomer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.MProduct",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.MOrder", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MOrder", "CustomerId", "dbo.MCustomer");
            DropForeignKey("dbo.MProduct", "OrderId", "dbo.MOrder");
            DropIndex("dbo.MProduct", new[] { "OrderId" });
            DropIndex("dbo.MOrder", new[] { "CustomerId" });
            DropTable("dbo.MProduct");
            DropTable("dbo.MOrder");
            DropTable("dbo.MCustomer");
        }
    }
}
