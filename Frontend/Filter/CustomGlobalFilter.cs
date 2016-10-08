using System.Diagnostics;
using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Filter
{
    public class CustomGlobalFilter: IActionFilter
    {
        private readonly Stopwatch stopWatch;

        public CustomGlobalFilter()
        {
            stopWatch = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch.Reset();
            stopWatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopWatch.Stop();

            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "TestFilter")
            {
                if (filterContext.ActionDescriptor.ActionName == "FilterByGlobalFilter")
                {
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