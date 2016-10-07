using System.Web.Mvc;
using System.Web.Routing;
using Frontend.Constraint;
using Frontend.Handler;

namespace Frontend
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Create Http Handler
            routes.Add(new Route("mygithub", new GithubRouteHandler()));

            // Create Routes
            routes.MapMvcAttributeRoutes();
        }

        private static void CreateRoute(RouteCollection routes)
        {
            var routeValue = new RouteValueDictionary
            {
                { "Controller", "Home" },
                { "Action", "Index" }
            };

            routes.Add(new Route("home", routeValue, new MvcRouteHandler()));
        }

        private static void MapRouteWithRegexConstraint(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = @"\d+"  }
            );
        }

        private static void MapRouteWithConstraint(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Admin",
                url: "Account/Index/{user}",
                defaults: new { controller = "Account", action = "Index", user = UrlParameter.Optional },
                constraints: new { user = new UserRouteConstraint("rdiegoni") }
            );
        }

        private static void MapRoute(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
