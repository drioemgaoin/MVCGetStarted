using System.Web;
using System.Web.Routing;

namespace Frontend.Handler
{
    public class GithubRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new GithubHttpHandler();
        }
    }
}