﻿using System;
using System.Collections.Generic;
using Nancy;

namespace Doublewide.Web.Modules
{
    public class DefaultModule : NancyModule
    {
        public DefaultModule()
        {
            var model = new List<BlogPostModel>
            {
                new BlogPostModel { Title = "First post!", Timestamp = DateTime.Now.AddDays(-3).ToString("d") },
                new BlogPostModel { Title = "Welcome to the site!", Timestamp = DateTime.Now.ToString("d") }
            };

            Get["/"] = parameters => View["default.cshtml", model];
        }
    }

    public class BlogPostModel
    {
        public string Title { get; set; }
        public string Timestamp { get; set; }
    }
}