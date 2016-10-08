using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class TestModelBindingController : Controller
    {
        [HttpGet]
        [Route("TestModelBinding", Name = "TestModelBinding")]
        public ActionResult Index()
        {
            return View(new DateModel());
        }

        [HttpPost]
        [Route("TestModelBinding", Name = "TestModelBinding_Post")]
        public ActionResult TestModelBinding(DateModel model)
        {
            return View("Index", model);
        }
    }
}