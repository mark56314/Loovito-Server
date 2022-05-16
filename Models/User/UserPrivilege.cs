using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserPrivilege
    {
        public int Id { get; set; }
        public bool CanAddProduct { get; set; }
        public bool CanDeleteProduct { get; set; }
        public bool CanEditProduct { get; set; }
        public bool CanSeeAnalytics { get; set; }
        public bool CanAddUser { get; set; }
        public bool CanEditUser { get; set; }
        public bool CanDeleteUser { get; set; }
        public bool CanSeeSoldProduct { get; set; }
    }
}