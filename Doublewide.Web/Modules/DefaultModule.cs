using System.Linq;
using Doublewide.Application.Services.Contracts;
using Doublewide.Web.Models;
using Doublewide.Web.ViewModels;
using Nancy;
using Omu.ValueInjecter;

namespace Doublewide.Web.Modules
{
    public class DefaultModule : NancyModule
    {
        private readonly IBlogService _blogService;

        public DefaultModule(IBlogService blogService)
        {
            //Injection
            _blogService = blogService;

            //Routes
            Get["/"] = parameters => Default(parameters);
        }

        private Response Default(dynamic parameters)
        {
            var posts = _blogService.GetLastNPosts(4);

            var postModels = posts.Select(x =>
                                              {
                                                  var m = new BlogPostModel();
                                                  m.InjectFrom(x);
                                                  return m;
                                              }).ToList();

            var viewModel = new HomepageViewModel
                                {
                                    FeaturedPost = postModels.FirstOrDefault(),
                                    Posts = postModels.Skip(1)
                                };

            return View["default.cshtml", viewModel];
        }
    }
}