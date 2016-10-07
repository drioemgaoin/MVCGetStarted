using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        [Route("", Name = "Home")]
        public ActionResult Index()
        {
            return View();
        }
    }
}