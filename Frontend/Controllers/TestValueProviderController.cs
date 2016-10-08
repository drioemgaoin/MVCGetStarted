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
            HttpContext.Response.Cookies.Add(new HttpCookie("id", "3"));
            return View(model);
        }

        [HttpPost]
        [Route("TestValueProvider", Name = "TestValueProvider_Post")]
        public ActionResult Index(ResultModel model, string id)
        {
            model.Id = id;
            return View(model);
        }
    }
}