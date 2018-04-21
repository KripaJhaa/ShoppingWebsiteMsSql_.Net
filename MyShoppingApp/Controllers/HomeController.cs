using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShoppingApp.DAL;
using MyShoppingApp.ViewModels;
using MyShoppingApp.Models;
using System.Collections;
using Microsoft.Ajax.Utilities;

namespace MyShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        private ProductDb _db = new ProductDb();

     
        
        public ActionResult Index(string SearchedString)
        {
            var products = from s in _db.Products
                           select s;

            if (String.IsNullOrEmpty(SearchedString))
                return View(products);

            products = products.Where(s => s.Name.Contains(SearchedString) || s.Category.Contains(SearchedString));

            if (products.Count() == 0)
                return RedirectToAction("MessageDetails");

            return View("ShowSearchResult", products.ToList());
        }

        public ActionResult MessageDetails()
        {
            return View();
        }


        public ActionResult CategoryDetails()
        {
            var products = from s in _db.Products.DistinctBy(row => row.Category)
                           select s;
            return View(products.ToList());
        }

        public ActionResult ShowSearchResult(List <Product> products)
        {
            return View(products);
        }

        public ActionResult LogOut()
        {
            Session["EmailId"] = null;
            return View("MessageLoggedOut");
        }

        public ActionResult MessageLoggedOut()
        {
            return View();
        }

    }
}