using System.Web.Mvc;
using System.Web.Mvc.Routing;
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
            //routes.Add(new Route("mygithub", new GithubRouteHandler()));

            // Create Constraints Routes
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("match", typeof(CustomRouteConstraint));

            // Create Routes
            routes.MapMvcAttributeRoutes(constraintsResolver);
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
                name: "RegExpRouteConstraint",
                url: "TestRouteConstraint/Regexp/{user}",
                defaults: new { controller = "TestRouteConstraint", action = "RegularExpressionConstraint", user = UrlParameter.Optional },
                constraints: new { user = "rdiegoni" } // 'user' identifies the parameter that the constraint applies to
            );

            routes.MapRoute(
                name: "CustomRouteConstraint",
                url: "TestRouteConstraint/Custom/{user}",
                defaults: new { controller = "TestRouteConstraint", action = "CustomRouteConstraint", user = UrlParameter.Optional },
                constraints: new { user = new CustomRouteConstraint("rdiegoni") } // 'user' identifies the parameter that the constraint applies to
            );
        }

        private static void MapRouteWithConstraint(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Admin",
                url: "TestRouteConstraint/Match/{user}",
                defaults: new { controller = "TestRouteConstraint", action = "Match", user = UrlParameter.Optional },
                constraints: new { user = new CustomRouteConstraint("rdiegoni") }
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
