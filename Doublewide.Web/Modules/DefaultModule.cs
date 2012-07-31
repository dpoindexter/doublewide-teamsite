using System;
using Nancy;

namespace Doublewide.Web.Modules
{
    public class DefaultModule : NancyModule
    {
        public DefaultModule()
        {
            Get["/"] = parameters =>
                           {
                               return View[DateTime.Now];
                           };
        }
    }
}