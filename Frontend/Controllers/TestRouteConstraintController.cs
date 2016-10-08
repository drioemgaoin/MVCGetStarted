using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class TestRouteConstraintController : Controller
    {
        [Route("TestRouteConstraint", Name = "TestRouteConstraint")]
        public ActionResult Index()
        {
            return View(new ResultModel());
        }

        [Route("TestRouteConstraint/Regexp/{user:regex(rdiegoni)}", Name = "TestRouteConstraint_RegularExpressionConstraint")]
        public ActionResult RegularExpressionConstraint(string user)
        {
            ViewBag.Message = "Regular Expression Constraint sucess";
            return View("Result");
        }

        [Route("TestRouteConstraint/Custom/{user:match(rdiegoni)}", Name = "TestRouteConstraint_CustomRouteConstraint")]
        public ActionResult CustomRouteConstraint(string user)
        {
            ViewBag.Message = "Custom Route Constraint sucess";
            return View("Result");
        }
    }
}