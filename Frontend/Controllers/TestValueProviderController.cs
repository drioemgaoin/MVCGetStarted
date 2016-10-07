using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class TestValueProviderController : Controller
    {
        [HttpGet]
        [Route("TestValueProvider", Name = "TestValueProvider")]
        public ActionResult Index()
        {
            var userModel = new UserModel();
            HttpContext.Response.Cookies.Add(new HttpCookie("id", "3"));
            return View(userModel);
        }

        [HttpPost]
        [Route("TestValueProvider", Name = "TestValueProvider_Post")]
        public ActionResult Index(UserModel model, string id)
        {
            return Content("Data provided by the new value provider: " + id);
        }
    }
}