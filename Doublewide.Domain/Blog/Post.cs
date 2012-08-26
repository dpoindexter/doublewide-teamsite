using System;
using System.Collections.Generic;
using Doublewide.Domain.Entities;
using ServiceStack.DataAnnotations;

namespace Doublewide.Domain.Blog
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
        public bool Published { get; set; }
        public IEnumerable<string> Tags { get; set; }

        [Ignore]
        public string AuthorLink
        {
            get { return Author.Replace(' ', '-').ToLowerInvariant(); }
        }
    }
}