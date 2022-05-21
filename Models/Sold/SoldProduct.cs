using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Helpers.Enum;

namespace WebApplication2.Models.Sold
{
    public class SoldProduct
    {
        public int Id { get; set; }
        public Product.Product Product { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public int SoldSum { get; set; }
        public Enums.Status Status { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        [MaxLength(20)]
        public string Size { get; set; }
    }
}