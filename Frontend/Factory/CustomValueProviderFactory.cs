using System.Web.Mvc;
using Frontend.ValueProvider;

namespace Frontend.Factory
{
    public class CustomValueProviderFactory: ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CustomValueProvider();
        }
    }
}