using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Doublewide.Modules
{
    public class DefaultModule : NancyModule
    {
        public DefaultModule()
        {
            Get["/"] = parameters => "Hello World";
        }
    }
}