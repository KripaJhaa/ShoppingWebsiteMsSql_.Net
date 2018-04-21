using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyShoppingApp.Models;

namespace MyShoppingApp.ViewModels
{
    public class MyOrdersViewModel
    {
        public MyOrdersViewModel()
        {
            Variants = new List<VariantViewModel>();
            
        }

        public List<VariantViewModel> Variants { get; set; }
        public string Address { get; set; }
        public int TotalAmount { get; set; }
         
    }
}