using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public String Address { get; set; }
        public String Designation { get; set; }
    }
}
