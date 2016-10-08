using System.Diagnostics;
using System.Web.Mvc;
using Frontend.Filter;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class TestFilterController : Controller
    {
        [Route("TestFilter", Name = "TestFilter")]
        public ActionResult Index()
        {
            var model = new FilterModel();
            model.MethodName = "Index";
            return View("Index", model);
        }

        [Route("FilterByOverrideMethod", Name = "FilterByOverrideMethod")]
        public ActionResult FilterByOverrideMethod()
        {
            var model = new FilterModel();
            model.MethodName = "FilterByOverrideMethod";
            return View("Index", model);
        }

        [CustomActionFilterAtttribute()]
        [Route("FilterByCustomActionFilterAttribute", Name = "FilterByCustomActionFilterAttribute")]
        public ActionResult FilterByCustomActionFilterAttribute()
        {
            var model = new FilterModel();
            model.MethodName = "FilterByCustomActionFilterAttribute";
            return View("Index", model);
        }

        [Route("FilterByFilterProvider", Name = "FilterByFilterProvider")]
        public ActionResult FilterByFilterProvider()
        {
            var model = new FilterModel();
            model.MethodName = "FilterByFilterProvider";
            return View("Index", model);
        }

        [Route("FilterByGlobalFilter", Name = "FilterByGlobalFilter")]
        public ActionResult FilterByGlobalFilter()
        {
            var model = new FilterModel();
            model.MethodName = "FilterByGlobalFilter";
            return View("Index", model);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.ActionDescriptor.ActionName == "FilterByOverrideMethod")
            {
                TempData["time"] = Stopwatch.StartNew();
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (filterContext.ActionDescriptor.ActionName == "FilterByOverrideMethod")
            {
                var stopWatch = TempData["time"] as Stopwatch;
                if (stopWatch != null)
                {
                    stopWatch.Stop();

                    var result = filterContext.Result as ViewResult;
                    if (result != null)
                    {
                        ((FilterModel)result.Model).ExecutionTime = stopWatch.Elapsed.TotalMilliseconds;
                    }
                }
            }
        }
    }
}