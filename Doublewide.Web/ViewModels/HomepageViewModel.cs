﻿using System.Collections.Generic;
using Doublewide.Web.Models;

namespace Doublewide.Web.ViewModels
{
    public class HomepageViewModel
    {
        public BlogPostModel FeaturedPost { get; set; }
        public IEnumerable<BlogPostModel> Posts { get; set; }
    }
}