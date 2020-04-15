using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWithVue.Models;

namespace AspNetCoreWithVue.Controllers
{
    
    public class HomeController : Controller
    {
        IEmployee _employee; 
        public HomeController(IEmployee employee)
        {
            this._employee = employee;
        }

        public JsonResult Index()
        {
            return Json(_employee.GetEmployees());
        }

        [HttpPost]
        public JsonResult Add([FromBody]Employee model)
        {
            Employee employee = new Employee
            {
                Name = model.Name,
                Address = model.Address,
                BirthDay = model.BirthDay,
                Department = model.Department
            };
            
            return Json(_employee.Add(employee));
        }

        [HttpPost]
        public JsonResult test(JsonResult model)
        {
           

            return Json(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
