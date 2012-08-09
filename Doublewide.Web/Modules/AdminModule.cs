using Doublewide.Web.Models;
using Nancy;
using Nancy.ModelBinding;

namespace Doublewide.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("/admin")
        {
            Get["/"] = parameters =>
                           {
                               var model = new AdminViewModel();
                               return View["default.cshtml", model];
                           };
        }
    }
}