using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Frontend.Binders;
using Frontend.Factory;
using Frontend.Filter;
using Frontend.Models;

namespace Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory));
            ValueProviderFactories.Factories.Add(new CustomValueProviderFactory());
            ModelBinders.Binders.Add(typeof(DateModel), new CustomModelBinder());
            FilterProviders.Providers.Add(new CustomFilterProvider());
            GlobalFilters.Filters.Add(new CustomGlobalFilter());
        }
    }
}
