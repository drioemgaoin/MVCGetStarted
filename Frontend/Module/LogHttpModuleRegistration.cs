using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Frontend.Module
{
    public static class LogHttpModuleRegistration
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(LogHttpModule));
        }
    }
}