using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShoppingApp.Models
{
    public class OrderedProduct
    {
        [Key]
        [Column(Order = 0)]
        public int VariantId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual Order Order { get; set; }

    }
}