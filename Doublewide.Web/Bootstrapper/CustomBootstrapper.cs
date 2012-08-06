using Nancy;
using Nancy.Diagnostics;
using ServiceStack.OrmLite;

namespace Doublewide.Web.Bootstrapper
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"password" }; }
        }

        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            //container.Register<OrmLiteConnectionFactory>();

            base.ConfigureApplicationContainer(container);
        }
    }
}