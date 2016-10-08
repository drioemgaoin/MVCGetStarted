using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Filter
{
    public class CustomActionFilterAtttribute: ActionFilterAttribute, IActionFilter
    {   
        private readonly Stopwatch stopWatch;

        public CustomActionFilterAtttribute()
        {
            stopWatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch.Reset();
            stopWatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
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