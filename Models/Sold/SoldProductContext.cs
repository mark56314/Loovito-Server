using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Sold
{
    public class SoldProductContext: DbContext
    {
        public DbSet<SoldProduct> SoldProducts { get; set; }
    }
}