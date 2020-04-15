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
