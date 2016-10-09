using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class TestValidationController : Controller
    {
        [HttpGet]
        [Route("TestValidation", Name = "TestValidation")]
        public ActionResult Index()
        {
            return View(new ValidationModel());
        }

        [HttpPost]
        [Route("TestValidation", Name = "TestValidation_Post")]
        public ActionResult Validate(ValidationModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Message = "Server side: Model is not valid";
                return View("Index", model);
            }

            model.Message = "Server side: Model is valid";
            return View("Index", model);
        }
    }
}