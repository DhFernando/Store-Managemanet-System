using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithVue.Models;
using AspNetCoreWithVue.Models.Advertistment;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWithVue.Controllers
{
    public class AdvertistmentController : Controller
    {
        IAdvertistment _advertistment;
        public AdvertistmentController(IAdvertistment advertistment )
        {
            this._advertistment = advertistment;
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            return Json(_advertistment.GetAllCategories());
        }


        [HttpPost]
        public JsonResult Add([FromBody]AdvertistmentModel model)
        {
            AdvertistmentModel advertistment = new AdvertistmentModel
            {
                Item = model.Item,
                MainCategory = model.MainCategory,
                SubCategory = model.SubCategory,
                Price = model.Price,
                CreatorId = model.CreatorId
            };
            return Json(_advertistment.Add(advertistment));

            
        }

        [HttpGet]
        public JsonResult GetAllAdvertistments()
        {   
            return Json(_advertistment.GetAllAdvertistments());
        }

    }
}
