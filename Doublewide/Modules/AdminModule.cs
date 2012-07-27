using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Doublewide.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("/admin")
        {
            Get["/"] = parameters => "Hello admin";
        }
    }
}