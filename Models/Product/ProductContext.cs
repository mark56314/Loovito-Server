using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Product
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<SizeCL> SizeCLs { get; set; }
        public DbSet<SizeN> SizeNs { get; set; }
      //   public ProductContext()
      //   {
      //       Database.Delete();
      //       Database.CreateIfNotExists();
      //   }


    }
}