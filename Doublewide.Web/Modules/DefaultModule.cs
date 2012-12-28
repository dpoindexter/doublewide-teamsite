using System.Linq;
using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Blog;
using Doublewide.Web.Models;
using Doublewide.Web.ViewModels;
using Nancy;
using Doublewide.Web.Extensions;

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
            var postModels = _blogService
                .GetLastNPosts(4)
                .MapToInjectedModel<Post, BlogPostModel>()
                .ToList();

            var viewModel = new HomepageViewModel
                                {
                                    FeaturedPost = postModels.FirstOrDefault(),
                                    Posts = postModels.Skip(1)
                                };

            return View["default.cshtml", viewModel];
        }
    }
}