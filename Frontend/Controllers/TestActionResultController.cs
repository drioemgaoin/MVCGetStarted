using System.Web.Mvc;
using Frontend.Action;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class TestActionResultController : Controller
    {
        [HttpGet]
        [Route("TestActionResult", Name = "TestActionResult")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("TestActionResult", Name = "TestActionResult_Post")]
        public ActionResult TestActionResult(string message)
        {
            var model = new ResultModel();
            model.Message = message;
            return new XmlActionResult(model);
        }
    }
}