using Doublewide.Web.Models;
using Nancy;
using Nancy.ModelBinding;

namespace Doublewide.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("/admin")
        {
            Get["/"] = parameters => View["default.cshtml"];

            Get["/season"] = parameters =>
            {
                var model = new { };
                return View["season.cshtml", model];
            };

            Post["/season"] = parameters =>
            {
                var season = this.Bind<SeasonEditingModel>();
                return View["foo"];
            };
        }
    }
}