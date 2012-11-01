using System.Configuration;
using Nancy;
using Nancy.Conventions;
using Nancy.Diagnostics;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Doublewide.Web.Bootstrapper
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"password" }; }
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("Content")
            );
        }

        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var connectionString = ConfigurationManager.ConnectionStrings["DoublewideConnection"].ConnectionString;

            container.Register<IDbConnectionFactory>(
                (c, p) => new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance));
        }
    }
}