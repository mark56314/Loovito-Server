using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Helpers.Enum;

namespace WebApplication2.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Material  Material { get; set; }
        public Season Season { get; set; }
        public Color Color { get; set; }
        public Country Country { get; set; }
        public Enums.Status Status { get; set; }
        public string QrCode { get; set; }
        public DateTime AddDate { get; set; }
        public int RealSum { get; set; } = 0;
        public int MinSum { get; set; } = 0;
        public int SellSum { get; set; } = 0;
        public string SizeIndex { get; set; } = "Number";
        public SizeCL SizeCL { get; set; }
        public SizeN SizeN { get; set; }
        public string[] PicPath { get; set; }
    }

}
