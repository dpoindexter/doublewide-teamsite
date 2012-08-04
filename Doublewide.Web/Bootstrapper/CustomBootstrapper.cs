using Nancy;
using Nancy.Diagnostics;

namespace Doublewide.Web.Bootstrapper
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"password" }; }
        }
    }
}