using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class TestActionInvokerController : Controller
    {
        [Route("TestActionInvoker", Name = "TestActionInvoker")]
        public ActionResult Index()
        {
            return new EmptyResult();
        }
    }
}