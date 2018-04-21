using MyShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingApp.ViewModels
{
    public class ProductViewModel
    {

        public ProductViewModel()
        {
            SelectedColor = "Random";
        }

        public string SearchedProduct { get; set; }

        public bool IsColorSelected { get; set; }

        public string SelectedColor { get; set; }



        public Product Product { get; set; }

    }
}