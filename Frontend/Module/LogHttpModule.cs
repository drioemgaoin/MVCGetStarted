using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Frontend.Module
{
    public class LogHttpModule: IHttpModule
    {
        private bool disposed;
        private HttpApplication context;

        public void Init(HttpApplication context)
        {
            this.context = context;
            context.BeginRequest += OnBeginRequest;
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Begin Request");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    context.BeginRequest -= OnBeginRequest;
                    disposed = true;
                }
            }
        }
    } 
}