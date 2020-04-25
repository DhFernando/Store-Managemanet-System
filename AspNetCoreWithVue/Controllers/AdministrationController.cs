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

        [HttpGet]
        public async Task<JsonResult> GetRoleWithUsers()
        {
            var res = new List<RoleWithUsers>();
            var roles = roleManager.Roles;
            foreach(var role in roles)
            {
                var model = new RoleWithUsers
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                
                foreach(var user in userManager.Users)
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user);
                    }
                }

                res.Add(model);
            }

            return Json(res);

        }

        [HttpGet]
        public async Task<JsonResult> GetUserRoles(String id)
        {
            var res = new List<UserWithRole>();
           
            var user = await userManager.FindByIdAsync(id);

            if (user == null) { return Json("null"); }

            
            
            foreach(var role in roleManager.Roles)
            {
                var model = new UserWithRole() {  Role = role ,  UserId = user.Id };

                if(await userManager.IsInRoleAsync(user, role.Name))
                {

                    model.roleIsAssign = true;
                    
                }
                else
                {

                    model.roleIsAssign = false;
                   
                }
               
                res.Add(model);

            }
            return Json(res);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateUserRoles([FromBody]List<UserWithRole> Objects)
        {
            foreach(var obj in Objects)
            {
                var user = await userManager.FindByIdAsync(obj.UserId);
                //var role = await roleManager.FindByIdAsync(obj.Role.Id); --> i have role name form font end then i dont want find it again
                // IdentityResult result = null;
                if (user != null)
                {
                    if(obj.roleIsAssign && !await userManager.IsInRoleAsync(user, obj.Role.Name))
                    {
                        await userManager.AddToRoleAsync(user, obj.Role.Name);
                    }
                    else if (!obj.roleIsAssign && await userManager.IsInRoleAsync(user, obj.Role.Name))
                    {
                        await userManager.AddToRoleAsync(user, obj.Role.Name);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return Json("Updated");
        }

    }
}
