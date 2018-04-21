using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShoppingApp.Models
{
    public class Cart
    {

        public int CartId { get; set; }

        public int VariantId { get; set; }
        public string PersonId { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }

        [ForeignKey("VariantId")]
        public virtual  Variant Variant{ get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}