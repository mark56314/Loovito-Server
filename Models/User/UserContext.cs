using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.User
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPrivilege> UserPrivileges {get; set;}
        public DbSet<Job> Jobs { get; set; }
    }
}