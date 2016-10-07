using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class AccountController : Controller
    {
        [Route("", Name = "Index")]
        public ActionResult Index(string user)
        {
            return View();
        }
    }
}