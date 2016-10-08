using System;
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
            var model = new ResultModel();
            HttpContext.Response.Cookies.Add(new HttpCookie("message", "Welcome {0}!! I'm a message provided by the custom value provider"));
            return View(model);
        }

        [HttpPost]
        [Route("TestValueProvider", Name = "TestValueProvider_Post")]
        public ActionResult Index(ResultModel model, string message)
        {
            model.Message = String.Format(message, model.Name);
            return View(model);
        }
    }
}