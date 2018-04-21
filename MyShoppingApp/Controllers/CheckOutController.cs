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
    public class CheckOutController : Controller
    {
        private ProductDb db = new ProductDb();

        // GET: CheckOut
        public ActionResult Index()
        {
            var cartObj = db.Carts;

            List<VariantViewModel> Listvartient = new List<VariantViewModel>();

            foreach (var items in cartObj)
            {
                var objVVM = new VariantViewModel();

                var id = items.VariantId;
                var ThatVarient = db.Variants.Find(id);

                objVVM.Image = ThatVarient.Product.Image;
                objVVM.Name = ThatVarient.Product.Name;
                objVVM.Description = ThatVarient.Product.Description;
                objVVM.Category = ThatVarient.Product.Category;
                objVVM.Size = ThatVarient.Size;
                objVVM.Color = ThatVarient.Color;
                objVVM.Price = ThatVarient.Price;
                objVVM.Count = items.Count;
                objVVM.TotalPrice = items.TotalPrice;
                objVVM.CartId = items.CartId;

                Listvartient.Add(objVVM);
            }

            return View(Listvartient);
        }

        public ActionResult Message(string Address)
        {

            int total = 0;
            foreach (var variant in db.Carts)
            {
                if (variant.PersonId.Equals(Session["EmailId"].ToString()))
                {
                    total = total + variant.TotalPrice;
                }
            }
            Order CurrOrder = new Order();

            CurrOrder.PersonId = Session["EmailId"].ToString();
            CurrOrder.Address = Address;
            CurrOrder.TotalAmount = total;

            db.Orders.Add(CurrOrder);
            db.SaveChanges();

            int rowno=0;
            foreach(var order in db.Orders)
            {
                rowno = order.OrderId;
            }

            //foreach (var variant in db.Carts)
            //{
            var results = (from a in db.Carts select a).ToList();
            foreach (var variant in results)
            {
                if (variant.PersonId.Equals(Session["EmailId"].ToString()))
                {
                    OrderedProduct p = new OrderedProduct();
                    p.VariantId = variant.VariantId;

                    p.OrderId = rowno;

                    p.Quantity = variant.Count;

                    db.OrderedProducts.Add(p);

                    db.SaveChanges();
                }

            }


            foreach (var variant in results)
            {
                if (variant.PersonId.Equals(Session["EmailId"].ToString()))
                {
                    db.Carts.Remove(variant);
                    db.SaveChanges();
                }
                
            }
            
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
