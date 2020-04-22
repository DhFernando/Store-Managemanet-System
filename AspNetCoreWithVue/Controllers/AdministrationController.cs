using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithVue.Models.Admistration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWithVue.Controllers
{
    public class AdministrationController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetAllApplicationUsers()
        {
            var users = userManager.Users;

            return Json(users);
        }

        [HttpPost]
        [Authorize]
        public JsonResult DeleteEmployee([FromBody]IdentityUser data)
        {

            return Json(data);

        }

        [HttpPost]
        public async Task<JsonResult> GetApplicationUser([FromBody]IdentityUser model)
        {
             var user = await userManager.FindByIdAsync(model.Id);
            
            return Json(user);
            
        }

        [HttpPost]
        public async Task<JsonResult> DeleteApplicationUser([FromBody]IdentityUser model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            if(user == null)
            {
                return Json("user Not Found");
            }
            var result = await userManager.DeleteAsync(user);
            return Json(result);

        }
    }
}
