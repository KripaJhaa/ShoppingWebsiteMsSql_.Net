using MyShoppingApp.DAL;
using MyShoppingApp.Models;
using MyShoppingApp.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MyShoppingApp.Controllers
{
    public class CartController : Controller
    {
        private ProductDb db = new ProductDb();

        // GET: Cart
        public ActionResult ShowCart()
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("MessageDetails");
            }

            List<VariantViewModel> ListVarient = (new SelectedDataList()).GetSelected();
            

            return View("AddProducts",ListVarient);
        }

        public ActionResult MessageDetails()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProducts()
        {

            List<VariantViewModel> CheckedList = (List<VariantViewModel>)TempData["CheckedList"];


            

            UpdateDbClass obj = new UpdateDbClass();
            obj.UpdateDb(CheckedList, Session["EmailId"].ToString());
            
            List<VariantViewModel> Listvartient = (new SelectedDataList()).GetSelected();


            return View(Listvartient);
        }

        public ActionResult Remove(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart variant = db.Carts.Find(Id);
            if (variant == null)
            {
                return HttpNotFound();
            }
           
            db.Carts.Remove(variant);
            db.SaveChanges();
            
            return RedirectToAction("ShowCart");
        }

    }
}
