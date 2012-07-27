using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Doublewide.Modules
{
    public class SeasonModule : NancyModule
    {
        public SeasonModule() : base("/season")
        {
            Get["/"] = parameters => "Hello season";
        }
    }
}