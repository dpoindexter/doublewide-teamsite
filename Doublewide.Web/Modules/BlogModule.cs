using Nancy;

namespace Doublewide.Web.Modules
{
    public class BlogModule : NancyModule
    {
        public BlogModule() : base("/blog")
        {
            Get["/"] = parameters => "Hello blog";
        }
    }
}