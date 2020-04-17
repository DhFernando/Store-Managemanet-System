using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Account
{
    public class RegistrationModel
    {
        [Required]
        public String Email { get; set; }
        [Required][DataType(DataType.Password)]
        public String Password { get; set; }
        [Required][DataType(DataType.Password)][Compare("Password")]
        public String ConfirmPassword { get; set; }
    }
}
