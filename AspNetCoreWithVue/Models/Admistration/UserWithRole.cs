using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Admistration
{
    public class UserWithRole
    {
        
        public String UserId { get; set; }
        public bool roleIsAssign { get; set; }
        public IdentityRole Role { get; set; }
    }
}
