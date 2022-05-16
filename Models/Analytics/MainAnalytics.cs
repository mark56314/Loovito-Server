using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Analytics
{
    public class MainAnalytics
    {
        public int Products { get; set; } = 0;
        public int ProductsRealSum { get; set; } = 0;
        public int CanEarn { get; set; } = 0;
        public int WasEarn { get; set; } = 0;
        public int WasSold { get; set; } = 0;

    }
}