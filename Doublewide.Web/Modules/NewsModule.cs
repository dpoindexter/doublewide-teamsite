using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;
using Doublewide.Web.Models;
using Doublewide.Web.ViewModels;
using Nancy;
using Doublewide.Web.Extensions;

namespace Doublewide.Web.Modules
{
    public class NewsModule : NancyModule
    {
        private readonly IBlogService _blogService;

        public NewsModule(IBlogService blogService) 
            : base("/news")
        {
            //Injection
            _blogService = blogService;

            //Routes
            Get["/"] = parameters => Default(parameters);
        }

        private Response Default(dynamic parameters)
        {
            var postModels = _blogService
                .GetAllPosts(PostStatus.Published)
                .MapToInjectedModel<Post, BlogPostModel>();

            var viewModel = new NewsViewModel
            {
                Posts = postModels
            };

            return View["default.cshtml", viewModel];
        }
    }
}