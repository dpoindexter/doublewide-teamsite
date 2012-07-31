using Nancy;

namespace Doublewide.Web.Modules
{
    public class TeamModule : NancyModule
    {
        public TeamModule() : base("/team")
        {
            Get["/"] = parameters => "Hello Team";
        }
    }
}