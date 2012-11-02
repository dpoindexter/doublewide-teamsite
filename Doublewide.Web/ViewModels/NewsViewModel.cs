using System.Collections.Generic;
using Doublewide.Web.Models;

namespace Doublewide.Web.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<BlogPostModel> Posts { get; set; }
    }
}