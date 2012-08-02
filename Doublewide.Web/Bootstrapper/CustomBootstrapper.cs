using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using TinyIoC;
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