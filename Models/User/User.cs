using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Helpers.Enum;

namespace WebApplication2.Models.User
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public Job Job { get; set; }
        [Required, MaxLength(30)]
        public string Login { get; set; }
        [Required, MaxLength(30)]
        public string Password { get; set; }
        public int Salary { get; set; }
        public DateTime WorkDate { get; set; }
        public UserPrivilege Privilege { get; set; }
        public Enums.Status Status { get; set; }
        public string Pic { get; set; }
    }
}