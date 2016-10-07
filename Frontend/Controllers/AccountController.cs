using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class AccountController : Controller
    {
        [Route("Account", Name = "Account")]
        public ActionResult Index(string user)
        {
            return View();
        }
    }
}