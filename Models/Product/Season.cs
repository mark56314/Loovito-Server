using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Product
{
    public class Season
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

    }
}