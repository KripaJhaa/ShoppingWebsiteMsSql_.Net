using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShoppingApp.ViewModels;
using MyShoppingApp.DAL;
using MyShoppingApp.Models;

namespace MyShoppingApp.Controllers
{
    public class AccountController : Controller
    {

        private ProductDb db = new ProductDb();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(Person Model)
        {

            //if (!ValidateSignUp(viewModel))
            //    return View(viewModel);

            try
            {
                if (ModelState.IsValid)
                {
                    var get_user = db.Persons.FirstOrDefault(p => p.EmailId == Model.EmailId);

                    // insert the user into the database!

                    if (get_user == null)
                    {
                        db.Persons.Add(Model);
                        db.SaveChanges();
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "EmailId already exists");
                        return View();
                    }

                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("ModelStateException", ex);
            }


            return View(Model);
        }




        [HttpPost]
        public ActionResult Login([Bind(Include = "EmailId, Password")] Login user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = db.Persons.Where(a => a.EmailId.Equals(user.EmailId) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (newUser != null)
                    {
                        Session["EmailId"] = newUser.EmailId.ToString();
                        Session["Name"] = newUser.Name.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "EmailId or Password is invalid !!!");
                        return View();
                    }
                }
            }


            catch (Exception ex)
            {
                ModelState.AddModelError("ModelStateException", ex);
            }

            return View(user);
        }

        public ActionResult ShowOrders()
        {

            if (Session["EmailId"] == null)
            {
                return RedirectToAction("MessageDetails");
            }

            List<MyOrdersViewModel> ModelList = new List<MyOrdersViewModel>();


            foreach(Order order in db.Orders)
            {
                if(order.PersonId.Equals(Session["EmailId"].ToString()))
                {
                    MyOrdersViewModel model = new MyOrdersViewModel();
                    model.Address = order.Address;
                    model.TotalAmount = order.TotalAmount;

                    foreach (OrderedProduct variant in db.OrderedProducts)
                    {
                        if(variant.OrderId == order.OrderId)
                        {
                            var obj =( from s in db.Variants
                                       where s.VariantId == variant.VariantId
                                       select s
                                    ).Single();

                            var count = 0;

                           foreach(var item in db.OrderedProducts)
                            {
                                if (item.VariantId == variant.VariantId && order.OrderId==variant.OrderId)
                                {
                                    count = item.Quantity;
                                }
                            }

                            var productDetail = (from s in db.Products
                                                 where s.ProductId == obj.ProductId
                                                 select s
                                                ).Single();

                            VariantViewModel VVMObj = new VariantViewModel();
                            VVMObj.Name = productDetail.Name;
                            VVMObj.ProductId = productDetail.ProductId;
                            VVMObj.Description = productDetail.Description;
                            VVMObj.Category = productDetail.Category;
                            VVMObj.Color = obj.Color;
                            VVMObj.Size = obj.Size;
                            VVMObj.Quantity = count;
                            model.Variants.Add(VVMObj);
                        }

                    }
                    

                    ModelList.Add(model);
                }

            }

            return View(ModelList);

        }

        public ActionResult MessageDetails()
        {
            return View();
        }

        //private bool ValidateSignUp(RegisterViewModel viewModel)
        //{

        //    if (!viewModel.ConfirmPassword.Equals(viewModel.person.Password))
        //    {
        //        ModelState.AddModelError("", "Confirm Password does not match Password");
        //        return false;
        //    }
        //    return true;
        //}

    }
}