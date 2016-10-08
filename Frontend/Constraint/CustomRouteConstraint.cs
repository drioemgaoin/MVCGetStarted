using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Frontend.Constraint
{
    public class CustomRouteConstraint: IRouteConstraint
    {
        private readonly List<string> users;

        public CustomRouteConstraint(string users)
        {
            this.users = users.Split('|').Select(x => x.ToLower()).ToList();
        }

        public bool Match(
            HttpContextBase httpContext, 
            Route route, 
            string parameterName, 
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var value = values[parameterName].ToString();
            return users.Contains(value.ToLower());
        }
    }
}