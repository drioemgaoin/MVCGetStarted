using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Frontend.Factory
{
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllername = requestContext.RouteData.Values["controller"].ToString();

            var controllerType = Type.GetType($"Frontend.Controllers.{controllername}Controller");

            return Activator.CreateInstance(controllerType) as IController;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var dispose = controller as IDisposable;
            dispose?.Dispose();
        }
    }
}