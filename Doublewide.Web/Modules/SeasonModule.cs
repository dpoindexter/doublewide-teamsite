using Nancy;

namespace Doublewide.Web.Modules
{
    public class SeasonModule : NancyModule
    {
        public SeasonModule() : base("/season")
        {
            Get["/"] = parameters => "Hello season";
        }
    }
}