using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Frontend.Action;

namespace Frontend.Factory
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllername = $"{requestContext.RouteData.Values["controller"]}Controller";

            var controllers = GetControllers();
            var controllerType = controllers.FirstOrDefault(x => x.Name == controllername);
            if (controllerType != null)
            {
                var controller = Activator.CreateInstance(controllerType) as IController;
                if (controllerName == "TestActionInvoker")
                {
                    return ReplaceActionInvoker(controller);
                }

                return controller;
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

        private static IController ReplaceActionInvoker(IController controller)
        {
            var mvcController = controller as Controller;
            if (mvcController != null)
            {
                mvcController.ActionInvoker = new MyControllerActionInvoker();
            }

            return mvcController;
        }
    }
}