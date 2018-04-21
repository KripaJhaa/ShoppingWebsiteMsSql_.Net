using MyShoppingApp.ViewModels;
using System.Collections.Generic;


namespace MyShoppingApp.DAL
{

    public class SelectedDataList
    {
        ProductDb obj = new ProductDb();

        public List<VariantViewModel> GetSelected()
        {

            List<VariantViewModel> Listvartient = new List<VariantViewModel>();

            foreach (var items in obj.Carts)
            {
                var objVVM = new VariantViewModel();

                var id = items.VariantId;
                var ThatVarient = obj.Variants.Find(id);

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

            return Listvartient;
        }
         
    }

}