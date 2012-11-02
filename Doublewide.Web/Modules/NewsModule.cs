using System.Linq;
using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Enums;
using Doublewide.Web.Models;
using Doublewide.Web.ViewModels;
using Nancy;
using Omu.ValueInjecter;

namespace Doublewide.Web.Modules
{
    public class NewsModule : NancyModule
    {
        private readonly IBlogService _blogService;

        public NewsModule(IBlogService blogService) : base("/news")
        {
            //Injection
            _blogService = blogService;

            //Routes
            Get["/"] = parameters => Default(parameters);
        }

        private Response Default(dynamic parameters)
        {
            var posts = _blogService.GetAllPosts(PostStatus.Published);

            var postModels = posts.Select(x =>
            {
                var m = new BlogPostModel();
                m.InjectFrom(x);
                return m;
            }).ToList();

            var viewModel = new NewsViewModel
            {
                Posts = postModels
            };

            return View["default.cshtml", viewModel];
        }
    }
}