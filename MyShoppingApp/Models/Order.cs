using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShoppingApp.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public string Address { get; set; }

        public string PersonId { get; set; }

        public int TotalAmount { get; set; }

        public virtual Person Person { get; set; }
    }
}