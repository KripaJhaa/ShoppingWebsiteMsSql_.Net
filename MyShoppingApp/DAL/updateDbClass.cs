using MyShoppingApp.Models;
using MyShoppingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingApp.DAL
{
    public class UpdateDbClass
    {
        private ProductDb db = new ProductDb();

        public void  UpdateDb(List<VariantViewModel> list,string personID)
        {

            List<VariantViewModel> CheckedList = list;


            foreach (var variant in CheckedList)
            {
                int flag = 0;
                foreach (Cart c in db.Carts)
                {
                    if (c.VariantId == variant.Id)
                    {
                        c.Count++;
                        flag = 1;
                        c.TotalPrice = variant.Price * c.Count;
                        break;
                    }
                }

                if (flag != 1)
                {
                    Cart currvariant = new Cart();
                    currvariant.Count = 1;
                    currvariant.VariantId = variant.Id;
                    currvariant.TotalPrice = variant.Price;
                    currvariant.PersonId = personID;


                    db.Carts.Add(currvariant);   
                }
                db.SaveChanges();
            }
        }
    }
}