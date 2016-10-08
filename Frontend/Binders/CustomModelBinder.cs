using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Binders
{
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var day = request.Form.Get("Day");
            var month = request.Form.Get("Month");
            var year = request.Form.Get("Year");

            return new DateModel
            {
                Date = day + "/" + month + "/" + year
            };
        }
    }
}