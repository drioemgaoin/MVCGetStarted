﻿using System.Web;

namespace Frontend.Handler
{
    public class CustomHttpHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Redirect("https://github.com/drioemgaoin", true);
        }

        public bool IsReusable { get { return true; } }
    }
}