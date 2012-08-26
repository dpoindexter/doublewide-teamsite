﻿using System;
using System.Collections.Generic;
using Doublewide.Web.Models;
using Doublewide.Web.ViewModels;
using Nancy;

namespace Doublewide.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("/admin")
        {
            Get["/"] = parameters =>
            {
                var model = new AdminViewModel
                {
                    Posts = new List<BlogPostModel>
                    {
                        new BlogPostModel { Id = 1, Author = "Steven Darroh", Timestamp = DateTime.Now.AddDays(-3), Title = "Doublewide roster set" },
                        new BlogPostModel { Id = 2, Author = "Jerrod Wolfe", Timestamp = DateTime.Now.AddDays(-10), Title = "Check out these jersey!" }
                    }
                };

                return View["default.cshtml", model];
            };
        }
    }
}