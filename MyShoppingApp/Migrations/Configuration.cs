namespace MyShoppingApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyShoppingApp.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MyShoppingApp.DAL.ProductDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyShoppingApp.DAL.ProductDb context)
        {

            var products = new List<Product>
            {
                new Product { Name = "Moto G5s Plus (Lunar Grey, 64GB)", Category = "Phone", Description = "Silver Gray Style Phone", Image = "/ImageFolder/mobile1.jpg" },
                new Product { Name = "Yu Yureka Plus (Back, 64GB)", Category = "Phone", Description = "Deep Black Style Phone", Image = "/ImageFolder/mobile2.jpg" },
                new Product { Name = "Iphone (Gold, 64GB)", Category = "Phone", Description = "Gold Style Phone", Image = "/ImageFolder/mobile1.jpg" },

                new Product { Name = "Men Slim Fit Shirt", Category = "Cloth", Description = "Black", Image = "/ImageFolder/tshirt1.jpg" },
                new Product { Name = "Female Slim Fit Shirt", Category = "Cloth", Description = "Blue", Image = "/ImageFolder/tshirt2.jpg" },
                new Product { Name = "Human Slim Fit Shirt", Category = "Cloth", Description = "Pink", Image = "/ImageFolder/tshirt1.jpg" },

                new Product { Name = "Lenevo Legion", Category = "Laptop", Description = "Blue", Image = "/ImageFolder/laptop.jpg" },
                new Product { Name = "Hp envy", Category = "Laptop", Description = "Silver", Image = "/ImageFolder/laptop1.jpg" },
                new Product { Name = "Acer X series", Category = "Laptop", Description = "Black", Image = "/ImageFolder/laptop.jpg" },

                new Product { Name = "Grossries1", Category = "Grossries", Description = "Fresh & Delicious", Image = "/ImageFolder/grossries1.jpg" },
                new Product { Name = "Grossries2", Category = "Grossries", Description = "Fresh & Delicious", Image = "/ImageFolder/grossries2.jpg" },
                new Product { Name = "Grossries3", Category = "Grossries", Description = "Fresh & Delicious", Image = "/ImageFolder/grossries3.jpg" },


                new Product { Name = "Electronics1", Category = "electronic", Description = "electronics Product", Image = "/ImageFolder/electronics1.jpg" },
                new Product { Name = "Electronics2", Category = "electronic", Description = "Advance your Lifestyle", Image = "/ImageFolder/electronics2.jpg" },
                new Product { Name = "Electronics3", Category = "electronic", Description = "Advance your Lifestyle", Image = "/ImageFolder/electronics.jpg" },

                new Product { Name = "Wearable 1", Category = "wearable", Description = "Comfort at your Step", Image = "/ImageFolder/wear1.jpg" },
                new Product { Name = "Wearable 2", Category = "wearable", Description = "Comfort at your Step", Image = "/ImageFolder/wear2.jpg" },
                new Product { Name = "Wearable 3", Category = "wearable", Description = "Comfort at your Step", Image = "/ImageFolder/wear3.jpg" }



            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var variants = new List<Variant>
            {


                new Variant{Size="Kg 1",Color="Green",AvailableQty=23,Price=1341241,ProductId=10},
                new Variant{Size="Kg 2",Color="Brown",AvailableQty=23,Price=2341241,ProductId=10},


                new Variant{Size="Kg 1",Color="Green",AvailableQty=23,Price=1341241,ProductId=11},
                new Variant{Size="Kg 2",Color="Brown",AvailableQty=23,Price=2341241,ProductId=11},


                new Variant{Size="Kg 1",Color="Green",AvailableQty=23,Price=1341241,ProductId=12},
                new Variant{Size="Kg 2",Color="Brown",AvailableQty=23,Price=2341241,ProductId=12},


                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=13},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=13},


                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=14},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=14},



                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=15},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=15},

                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=16},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=16},


                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=17},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=17},


                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=18},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=18},


                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=7},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=7},
                new Variant{Size="12.5inch",Color="Yellow",AvailableQty=23,Price=3341241,ProductId=7},
                new Variant{Size="17.5inch",Color="Brown",AvailableQty=23,Price=5341241,ProductId=7},

                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=8},
                new Variant{Size="12inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=8},
                new Variant{Size="12.5inch",Color="Yellow",AvailableQty=23,Price=3341241,ProductId=8},
                new Variant{Size="17.5inch",Color="Brown",AvailableQty=23,Price=5341241,ProductId=8},

                new Variant{Size="15.5inch",Color="Red",AvailableQty=23,Price=1341241,ProductId=9},
                new Variant{Size="10.5inch",Color="Blue",AvailableQty=23,Price=2341241,ProductId=9},
                new Variant{Size="12.5inch",Color="Yellow",AvailableQty=23,Price=3341241,ProductId=9},
                new Variant{Size="17.5inch",Color="Brown",AvailableQty=23,Price=5341241,ProductId=9},


                new Variant{Size="S",Color="Red",AvailableQty=223,Price=141,ProductId=4},
                new Variant{Size="L",Color="Blue",AvailableQty=233,Price=231,ProductId=4},
                new Variant{Size="M",Color="Yellow",AvailableQty=243,Price=341,ProductId=4},
                new Variant{Size="Xl",Color="Brown",AvailableQty=23,Price=241,ProductId=4},

                new Variant{Size="S",Color="Red",AvailableQty=223,Price=141,ProductId=5},
                new Variant{Size="L",Color="Blue",AvailableQty=233,Price=231,ProductId=5},
                new Variant{Size="M",Color="Yellow",AvailableQty=243,Price=341,ProductId=5},
                new Variant{Size="Xl",Color="Brown",AvailableQty=23,Price=241,ProductId=5},

                new Variant{Size="Small",Color="Red",AvailableQty=223,Price=141,ProductId=6},
                new Variant{Size="Large",Color="Blue",AvailableQty=233,Price=231,ProductId=6},
                new Variant{Size="Medium",Color="Yellow",AvailableQty=243,Price=341,ProductId=6},
                new Variant{Size="Xl",Color="Brown",AvailableQty=23,Price=241,ProductId=6},

                new Variant{Size="5.5inch",Color="Red",AvailableQty=223,Price=141,ProductId=1},
                new Variant{Size="5.2inch",Color="Blue",AvailableQty=233,Price=231,ProductId=1},
                new Variant{Size="6 inch",Color="Yellow",AvailableQty=243,Price=341,ProductId=1},
                new Variant{Size="6.5 inch",Color="Brown",AvailableQty=23,Price=241,ProductId=1},

                new Variant{Size="5.5inch",Color="Red",AvailableQty=223,Price=141,ProductId=2},
                new Variant{Size="4.5inch",Color="Blue",AvailableQty=233,Price=231,ProductId=2},
                new Variant{Size="8.5inch",Color="Yellow",AvailableQty=243,Price=341,ProductId=2},
                new Variant{Size="9.5inch",Color="Brown",AvailableQty=23,Price=241,ProductId=2},

                new Variant{Size="5.5inch",Color="Red",AvailableQty=223,Price=141,ProductId=3},
                new Variant{Size="10.5inch",Color="Blue",AvailableQty=233,Price=231,ProductId=3},
                new Variant{Size="6.5inch",Color="Yellow",AvailableQty=243,Price=341,ProductId=3},
                new Variant{Size="7.5inch",Color="Brown",AvailableQty=23,Price=241,ProductId=3},

            };
            variants.ForEach(s => context.Variants.AddOrUpdate(p => p.VariantId, s));
            context.SaveChanges();

        }
    }
}
