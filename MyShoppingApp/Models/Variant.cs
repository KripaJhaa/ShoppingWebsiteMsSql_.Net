using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingApp.Models
{
    public class Variant
    {

        public int VariantId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int AvailableQty { get; set; }
        public int Price { get; set; }

        public int ProductId { get; set; }
        //public int CartId { get; set; }

        virtual public Product Product { get; set; }
        //virtual public Cart Cart { get; set; }
    }
}