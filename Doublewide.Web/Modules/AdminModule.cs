using Nancy;

namespace Doublewide.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("/admin")
        {
            Get["/"] = parameters => "Hello admin";
        }
    }
}