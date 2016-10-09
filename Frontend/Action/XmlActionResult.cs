using System.IO;
using System.Web.Mvc;
using System.Xml.Serialization;
using Frontend.Models;

namespace Frontend.Action
{
    public class XmlActionResult: ActionResult
    {
        private readonly ResultModel model;

        public XmlActionResult(ResultModel model)
        {
            this.model = model;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.HttpContext;
            httpContext.Response.Buffer = true;
            httpContext.Response.Clear();

            var response = context.HttpContext.Response;
            response.ContentType = "application/xml";

            using (var writer = new StringWriter())
            {
                var xml = new XmlSerializer(typeof(ResultModel));
                xml.Serialize(writer, model);
                httpContext.Response.Write(writer);
            }
        }
    }
}