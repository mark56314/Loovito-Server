using System;
using System.Data.Entity;
using WebApplication2.Helpers.Enum;
using WebApplication2.Models.Product;

namespace WebApplication2.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
       protected override void  Seed(ProductContext pd)
        {
            Material material = new Material { Name = "Хлопок" };
            Brand brand = new Brand { Name = "Adidas" };
            Season season = new Season { Name = "Осень" };
            Color color = new Color { Name = "Красный" };
            Country country = new Country { Name = "Турция" };
            SizeCL sizeCL = new SizeCL { S = 1, M = 3, L = 10 };
            SizeN sizeN = new SizeN { N36 = 1, N37 = 2, N38 = 5, N41 = 1 };
            pd.Colors.Add(color);
            pd.Countries.Add(country);
            pd.Brands.Add(brand);
            pd.Materials.Add(material);
            pd.Seasons.Add(season);
            pd.Products.Add(new Product.Product { Name = "Rfdfs",  Brand = brand, Material = material, MinSum=200,   Season = season, RealSum=100,   SellSum=300,   QrCode = "Q11", Status = Enums.Status.Active, AddDate= DateTime.Now, Color = color, Country = country, SizeCL = sizeCL, SizeN = sizeN, PicPath = new string[]{"fsdff","sdfsdfsd" } });
            pd.Products.Add(new Product.Product { Name = "Rfdfs", Brand = brand, Material = material, MinSum = 201, Season = season, RealSum = 101, SellSum = 301, QrCode = "Q11", Status = Enums.Status.Active, AddDate = DateTime.Now, Color = color, Country = country, SizeCL = sizeCL, SizeN = sizeN, PicPath = new string[] { "fsdff", "sdfsdfsd" } });
            pd.Products.Add(new Product.Product { Name = "Rfdfs", Brand = brand, Material = material, MinSum = 202, Season = season, RealSum = 102, SellSum = 302, QrCode = "Q11", Status = Enums.Status.Active, AddDate = DateTime.Now, Color = color, Country = country, SizeCL = sizeCL, SizeN = sizeN, PicPath = new string[] { "fsdff", "sdfsdfsd" } });
            pd.Products.Add(new Product.Product { Name = "Rfdfs", Brand = brand, Material = material, MinSum = 203, Season = season, RealSum = 103, SellSum = 303, QrCode = "Q11", Status = Enums.Status.Active, AddDate = DateTime.Now, Color = color, Country = country, SizeCL = sizeCL, SizeN = sizeN, PicPath = new string[] { "fsdff", "sdfsdfsd" } });
            pd.Products.Add(new Product.Product { Name = "Rfdfs", Brand = brand, Material = material, MinSum = 204, Season = season, RealSum = 104, SellSum = 304, QrCode = "Q11", Status = Enums.Status.Active, AddDate = DateTime.Now, Color = color, Country = country, SizeCL = sizeCL, SizeN = sizeN, PicPath = new string[] { "fsdff", "sdfsdfsd" } });
            pd.Products.Add(new Product.Product { Name = "Rfdfs", Brand = brand, Material = material, MinSum = 205, Season = season, RealSum = 105, SellSum = 305, QrCode = "Q11", Status = Enums.Status.Active, AddDate = DateTime.Now, Color = color, Country = country, SizeCL = sizeCL, SizeN = sizeN, PicPath = new string[] { "fsdff", "sdfsdfsd" } }); base.Seed(pd);
        }
    }
}