using System.Collections.Generic;
using System.Web.Mvc;

namespace Frontend.Filter
{
    public class CustomFilterProvider: IFilterProvider
    {
        public IEnumerable<System.Web.Mvc.Filter> GetFilters(
            ControllerContext controllerContext, 
            ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor.ControllerDescriptor.ControllerName == "TestFilter")
            {
                if (actionDescriptor.ActionName == "FilterByFilterProvider")
                {
                    yield return new System.Web.Mvc.Filter(new CustomActionFilterAtttribute(), FilterScope.Action, 0);
                }
            }
        }
    }
}