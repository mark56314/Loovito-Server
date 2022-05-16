using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Helpers.Enum;

namespace WebApplication2.Models.User
{
    public class UserDbInitializer: DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            UserPrivilege privilege = new UserPrivilege { CanAddProduct = true, CanAddUser = true, CanDeleteProduct = true, CanDeleteUser = true, CanEditProduct = true, CanEditUser = true, CanSeeAnalytics = true, CanSeeSoldProduct = true };
            Job job = new Job { Name = "Super Admin" };
            context.Jobs.Add(job);
            context.UserPrivileges.Add(privilege);
            User user = new User { Name = "Mark", LastName = "Melkov", Login = "Admin", Password = "admin", Pic = "Empty", Salary = 2000, Status = Enums.Status.Active, WorkDate = DateTime.Now, Job = job, Privilege = privilege };
            context.Users.Add(user);
            base.Seed(context);
        }
    }
}