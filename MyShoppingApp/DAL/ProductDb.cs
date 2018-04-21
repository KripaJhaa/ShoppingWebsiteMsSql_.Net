using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyShoppingApp.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyShoppingApp.DAL
{
    public class ProductDb : DbContext
    {

        public ProductDb() : base("PDb1")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OrderedProduct> OrderedProducts{ get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}