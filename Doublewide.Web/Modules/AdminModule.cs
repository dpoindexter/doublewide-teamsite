using System.Linq;
using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;
using Doublewide.Web.Models;
using Doublewide.Web.Models.Assemblers;
using Doublewide.Web.ViewModels;
using Nancy;
using Doublewide.Web.Extensions;

namespace Doublewide.Web.Modules
{
    public class AdminModule : NancyModule
    {
        private readonly IBlogService _blogService;
        private readonly ISeasonService _seasonService;

        public AdminModule(IBlogService blogService, ISeasonService seasonService) 
            : base("/admin")
        {
            //Injections
            _blogService = blogService;
            _seasonService = seasonService;

            //Routes
            Get["/"] = parameters => Default(parameters);
        }

        private Response Default(dynamic parameters)
        {
            var postModels = _blogService
                .GetAllPosts(PostStatus.Published)
                .MapToInjectedModel<Post, BlogPostModel>();

            var resultsModel = _seasonService
                .GetAllTournamentsForSeason()
                .Select(x => x.ToModel());

            var viewModel = new AdminViewModel
            {
                Posts = postModels,
                Tournaments = resultsModel
            };

            return View["default.cshtml", viewModel];
        }
    }
}