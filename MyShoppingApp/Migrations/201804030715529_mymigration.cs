namespace MyShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        VariantId = c.Int(nullable: false),
                        PersonId = c.String(maxLength: 128),
                        Count = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Variant", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.VariantId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        EmailId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.EmailId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PersonId = c.String(),
                        TotalAmount = c.Int(nullable: false),
                        Person_EmailId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Person", t => t.Person_EmailId)
                .Index(t => t.Person_EmailId);
            
            CreateTable(
                "dbo.Variant",
                c => new
                    {
                        VariantId = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                        Color = c.String(),
                        AvailableQty = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VariantId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderedProduct",
                c => new
                    {
                        VariantId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VariantId, t.OrderId })
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Variant", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.VariantId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedProduct", "VariantId", "dbo.Variant");
            DropForeignKey("dbo.OrderedProduct", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Cart", "VariantId", "dbo.Variant");
            DropForeignKey("dbo.Variant", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Cart", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Order", "Person_EmailId", "dbo.Person");
            DropIndex("dbo.OrderedProduct", new[] { "OrderId" });
            DropIndex("dbo.OrderedProduct", new[] { "VariantId" });
            DropIndex("dbo.Variant", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "Person_EmailId" });
            DropIndex("dbo.Cart", new[] { "PersonId" });
            DropIndex("dbo.Cart", new[] { "VariantId" });
            DropTable("dbo.OrderedProduct");
            DropTable("dbo.Product");
            DropTable("dbo.Variant");
            DropTable("dbo.Order");
            DropTable("dbo.Person");
            DropTable("dbo.Cart");
        }
    }
}
