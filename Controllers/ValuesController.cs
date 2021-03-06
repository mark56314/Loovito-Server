using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication2.Helpers.Enum;
using WebApplication2.Models;
using WebApplication2.Models.Analytics;
using WebApplication2.Models.Product;
using WebApplication2.Models.Sold;
using WebApplication2.Models.User;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        ProductContext pd = new ProductContext();
        SoldProductContext sold = new SoldProductContext();
        UserContext uc = new UserContext();
        IncomeContext ic = new IncomeContext();
        public IEnumerable<Product> GetProducts()
        {
            return pd.Products.Include(M => M.Material).Include(M => M.Color).Include(M => M.Country).Include(M => M.Brand).Include(M => M.Season).Include(M => M.SizeCL).Include(M => M.SizeN).Where(M => M.Status == Enums.Status.Active);
        }
        public IEnumerable<Job> GetJobs(string GetJobs)
        {
            return uc.Jobs;
        }
        public IEnumerable<User> GetUsers(string GetUsers)
        {
            return uc.Users;
        }
        public Finance GetFinance(DateTime StartDate, DateTime EndDate)
        {
            

        }

        public IEnumerable<Brand> GetBrands(string GetBrands)
        {
            return pd.Brands;
        }
        public IEnumerable<Country> GetCountries(string GetCountries)
        {
            return pd.Countries;
        }
        public IEnumerable<Color> GetColors(string GetColors)
        {
            return pd.Colors;
        }
        public IEnumerable<Material> GetMaterials(string GetMaterials)
        {
            return pd.Materials;
        }
        public IEnumerable<Season> GetSeasons(string GetSeasons)
        {
            return pd.Seasons;
        }
        public Product GetProduct(int Product)
        {
            if (pd.Products.Find(Product).SizeIndex == "Number")
            {
                return pd.Products.Include(M => M.Material).Include(M => M.Color).Include(M => M.Country).Include(M => M.Brand).Include(M => M.Season).Include(M=>M.SizeN).FirstOrDefault(M => M.Id == Product);
            }
            else
            {
                return pd.Products.Include(M => M.Material).Include(M => M.Color).Include(M => M.Country).Include(M => M.Brand).Include(M => M.Season).Include(M => M.SizeCL).FirstOrDefault(M => M.Id == Product);
            }
        }
        public IEnumerable<Product> GetQrCode(string QrCode)
        {
            return pd.Products.Where(x => x.QrCode.Contains(QrCode));
        }
        public User GetUser(int User)
        {
            return uc.Users.Include(M=>M.Privilege).Include(M=> M.Job).FirstOrDefault(M=>M.Id ==User);
        }

        public MainAnalytics GetMainAnalytics(DateTime StartDate, DateTime EndDate)
        {
            IEnumerable<Product> products = pd.Products.Include(M=>M.SizeN).Include(M=> M.SizeCL).Where(M=> M.Status == Enums.Status.Active).Where(M=>M.AddDate>StartDate && M.AddDate < EndDate);
            MainAnalytics analytics = new MainAnalytics();
            IEnumerable<SoldProduct> soldProducts = sold.SoldProducts.Include(M=> M.Product).Where(M => M.Status == Enums.Status.Sold).Where(M=>M.Date > StartDate && M.Date < EndDate);
            foreach (SoldProduct s in soldProducts)
            {
                analytics.WasEarn += s.SoldSum-s.Product.MinSum;
            }
            foreach (Product p in products)
            {
              int l =  p.SizeCL.L;
                l = p.SizeN.N36;
                if (p.SizeIndex == "Number")
                {
                    analytics.ProductsRealSum += (p.SizeN.N36 + p.SizeN.N37 + p.SizeN.N38 + p.SizeN.N39 + p.SizeN.N40 + p.SizeN.N41 + p.SizeN.N42 + p.SizeN.N43 + p.SizeN.N44 + p.SizeN.N45 + p.SizeN.N46 + p.SizeN.N47 + p.SizeN.N48 + p.SizeN.N49 + p.SizeN.N50) * p.RealSum;
                    analytics.CanEarn += (p.SizeN.N36 + p.SizeN.N37 + p.SizeN.N38 + p.SizeN.N39 + p.SizeN.N40 + p.SizeN.N41 + p.SizeN.N42 + p.SizeN.N43 + p.SizeN.N44 + p.SizeN.N45 + p.SizeN.N46 + p.SizeN.N47 + p.SizeN.N48 + p.SizeN.N49 + p.SizeN.N50) * p.MinSum;
                }
                else
                {
                    analytics.ProductsRealSum += (p.SizeCL.Xxs + p.SizeCL.Xs + p.SizeCL.S + p.SizeCL.M + p.SizeCL.L + p.SizeCL.Xl + p.SizeCL.Xxl + p.SizeCL.Xl3 + p.SizeCL.Xl4 + p.SizeCL.Xl5 + p.SizeCL.Xl6) * p.RealSum;
                    analytics.CanEarn+= (p.SizeCL.Xxs + p.SizeCL.Xs + p.SizeCL.S + p.SizeCL.M + p.SizeCL.L + p.SizeCL.Xl + p.SizeCL.Xxl + p.SizeCL.Xl3 + p.SizeCL.Xl4 + p.SizeCL.Xl5 + p.SizeCL.Xl6) * p.MinSum;
                }
            }
            analytics.Products = products.Count();
            analytics.WasSold = soldProducts.Count();
            return analytics;
        }

        public IEnumerable<SoldProduct> GetSoldProducts(DateTime Start, DateTime End)
        {
            return sold.SoldProducts.Where(M=> M.Date > Start && M.Date < End).Where(M=>M.Status == Enums.Status.Sold);
        }
        [HttpPost]
        public void CreateBook([FromBody] Product product)
        {
            pd.Products.Add(product);
            pd.SaveChanges();
        }
        public void SoldProduct([FromBody] SoldProduct product)
        {
            Product pro = pd.Products.Find(product.ProductId);
            product.Product = pro;
            sold.SoldProducts.Add(product);
            sold.SaveChanges();
        }
        public void CreateCountry([FromBody] Country country)
        {
            pd.Countries.Add(country);
            pd.SaveChanges();
        }
        public void CreateColor([FromBody] Color color)
        {
            pd.Colors.Add(color);
            pd.SaveChanges();
        }
        public void CreateMaterial([FromBody] Material material)
        {
            pd.Materials.Add(material);
            pd.SaveChanges();
        }
        public void CreateSeason([FromBody] Season season)
        {
            pd.Seasons.Add(season);
            pd.SaveChanges();
        }
        public void CreateBrand([FromBody] Brand brand)
        {
            pd.Brands.Add(brand);
            pd.SaveChanges();
        }
        public void CreateJob([FromBody] Job job)
        {
            uc.Jobs.Add(job);
            uc.SaveChanges();
        }

        public void CreateUser([FromBody] User user)
        {
            uc.Users.Add(user);
            uc.SaveChanges();
        }
        [HttpPut]
        public void EditBook(int id, [FromBody] Product product)
        {
            if (id == product.Id)
            {
                pd.Entry(product).State = EntityState.Modified;
                pd.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            Product product = pd.Products.Find(id);
            if(product != null)
            {
                product.Status = Enums.Status.Deleted;
                pd.Entry(product).State = EntityState.Modified;
                pd.SaveChanges();
            }
        }
        public void DeleteColor(string Color)
        {
            Color color = pd.Colors.Find(Color);
            if(color != null)
            {
                pd.Colors.Remove(color);
                pd.SaveChanges();
            }

        }
        public void DeleteMaterial(string Material)
        { 
            Material material = pd.Materials.Find(Material);
            if(material != null)
            {
                pd.Materials.Remove(material);
                pd.SaveChanges();
            }
        }
        public void DeleteSeason(string Season)
        { 
            Season season = pd.Seasons.Find(Season);
            if(season != null)
            {
                pd.Seasons.Remove(season);
                pd.SaveChanges();
            }
        }
        public void DeleteBrand(string Brand)
        { 
            Brand brand = pd.Brands.Find(Brand);
            if(brand != null)
            {
                pd.Brands.Remove(brand);
                pd.SaveChanges();
            }
        }

        public void DeleteCountry(string Country)
        { 
            Country country = pd.Countries.Find(Name);
            if(country != null)
            {
                pd.Countries.Remove(country);
                pd.SaveChanges();
            }
        }
        public void DeleteBook(int id)
        {
            Product product = pd.Products.Find(id);
            if (product != null)
            {
                pd.Products.Remove(product);
                pd.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
