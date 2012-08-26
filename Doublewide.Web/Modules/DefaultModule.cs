using System;
using System.Collections.Generic;
using System.Linq;
using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;
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
            var posts = _blogService.GetLastNPosts(3);

            var postModels = posts.Select(x =>
                                              {
                                                  var m = new BlogPostModel();
                                                  m.InjectFrom(x);
                                                  return m;
                                              });

            var viewModel = new HomepageViewModel{Posts = postModels};

            return View["default.cshtml", viewModel];
        }
    }
}