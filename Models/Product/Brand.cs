using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Product
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}