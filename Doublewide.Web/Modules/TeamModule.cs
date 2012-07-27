using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Doublewide.Modules
{
    public class TeamModule : NancyModule
    {
        public TeamModule() : base("/team")
        {
            Get["/"] = parameters => "Hello Team";
        }
    }
}