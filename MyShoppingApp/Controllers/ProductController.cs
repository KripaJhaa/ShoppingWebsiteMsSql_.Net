using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyShoppingApp.DAL;
using MyShoppingApp.Models;
using MyShoppingApp.ViewModels;

namespace MyShoppingApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductDb db = new ProductDb();

        //Get Products By Category
        public ActionResult CategoryProducts(string SearchedCategory)
        {
            var products = from s in db.Products
                           select s;
   
            products = products.Where(s => s.Category.Equals(SearchedCategory));

            return View(products.ToList());
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (Session["EmailId"] == null)
                return RedirectToAction("MessageDetails");


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var variants = new List<VariantViewModel>();
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            if (Session["EmailId"] != null)
            {
                foreach (var variant in product.Variants)
                {

                    var v = new VariantViewModel
                    {
                        Id = variant.VariantId,
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Image = product.Image,
                        Category = product.Category,
                        Description = product.Description,
                        Size = variant.Size,
                        Color = variant.Color,
                        AvailableQty = variant.AvailableQty,
                        Price = variant.Price,

                        Checked = false
                    };
                    variants.Add(v);
                }

                return View(variants);
            }

            return RedirectToAction("Login", "Account");
            
        }


        [HttpPost]
        public ActionResult Details(List<VariantViewModel> variantslist,int? id)
        {


            var CheckedList = new List<VariantViewModel>();
            foreach (var variant in variantslist)
            {
                if (variant.Checked == true)
                    CheckedList.Add(variant);
            }

            TempData["CheckedList"] = CheckedList;
            return RedirectToAction("AddProducts", "Cart");
        }


        public ActionResult MessageDetails()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
