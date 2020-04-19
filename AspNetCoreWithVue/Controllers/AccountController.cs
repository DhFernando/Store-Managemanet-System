using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithVue.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreWithVue.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
    
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
          
        }


        [HttpPost]
        public async Task<JsonResult> Register([FromBody]RegistrationModel model)
        {
           var headers = Request.Headers;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    var name = signInManager.IsSignedIn(User);
                    if (signInManager.IsSignedIn(User)) {
                        return Json("Your are LoggedIn");
                    }
                    else
                    {
                         return Json("Your Not Logged In");
                    }
                   
                }
                
            }
            return Json("Your Email has Alrady Exist");
        }

        [HttpGet]
        public JsonResult Gettest()
        {
            if (signInManager.IsSignedIn(User)) { return Json("yes"); }
            return Json("No");
        }

    }
}
