using System;
using System.Collections.Generic;

namespace Doublewide.Web.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
        public string AuthorLink { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}