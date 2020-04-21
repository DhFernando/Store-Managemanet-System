using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWithVue.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public JsonResult DeleteEmployee([FromBody]int id)
        {

            return Json(_employee.Delete(id));

        }
        

        [HttpGet]
        public JsonResult GetEmployee(int id)
        {

            return Json(_employee.GetEmployee(id));

        }






    }
}
