using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Frontend.Factory
{
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllername = $"{requestContext.RouteData.Values["controller"]}Controller";

            var controllers = GetControllers();
            var controller = controllers.FirstOrDefault(x => x.Name == controllername);
            if (controller != null)
            {
                return Activator.CreateInstance(controller) as IController;
            }

            return null;
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

        private static IEnumerable<Type> GetControllers()
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            return myAssembly.GetTypes()
                .Where(x => x.IsClass && x.Name.EndsWith("Controller")).ToList();
        }
    }
}