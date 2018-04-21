using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingApp.ViewModels
{
    public class VariantViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int AvailableQty { get; set; }

        public int Price { get; set; }

        public bool Checked { get; set; }

        public int SelectedQty { get; set; }

        public bool CanBeAdded { get; set; }

        public int Count { get; set; }
        public int TotalPrice { get; set; }

        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}