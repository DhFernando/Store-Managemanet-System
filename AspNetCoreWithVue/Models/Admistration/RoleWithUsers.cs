using AspNetCoreWithVue.Models.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Admistration
{
    public class RoleWithUsers
    {
        public RoleWithUsers()
        {
            Users = new List<ApplicationUser>();
        }
        public String RoleId { get; set; }
        public String RoleName { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
