using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Helpers.Enum;

namespace WebApplication2.Models.Sold
{
    public class SoldProductDbInitializer : DropCreateDatabaseAlways<SoldProductContext>
    {
        protected override void Seed(SoldProductContext context)
        {
            Product.ProductContext productContext = new Product.ProductContext();
            Product.Product product = productContext.Products.Find(1);
            SoldProduct soldProduct = new SoldProduct { Comment = "Нечего писать тут!", Date = DateTime.Now, Size = "L", SoldSum = 400, Status = Enums.Status.Sold,  Product = product};
            SoldProduct soldProduct1 = new SoldProduct { Comment = "Нечего писать тут!", Date = DateTime.Now, Size = "S", SoldSum = 400, Status = Enums.Status.Sold, Product = product };
            SoldProduct soldProduct2= new SoldProduct { Comment = "Нечего писать тут!", Date = DateTime.Now, Size = "XL", SoldSum = 400, Status = Enums.Status.Sold, Product = product };
            context.SoldProducts.Add(soldProduct);
            context.SoldProducts.Add(soldProduct1);
            context.SoldProducts.Add(soldProduct2);
            base.Seed(context);
        }
    }
}