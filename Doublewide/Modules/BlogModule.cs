using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Doublewide.Modules
{
    public class BlogModule : NancyModule
    {
        public BlogModule() : base("/blog")
        {
            Get["/"] = parameters => "Hello blog";
        }
    }
}