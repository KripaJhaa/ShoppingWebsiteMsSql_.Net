using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        virtual public ICollection<Variant> Variants { get; set; }


    }
}