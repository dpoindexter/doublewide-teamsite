using System;
using System.Collections.Generic;
using Doublewide.Domain.Entities;

namespace Doublewide.Domain.Blog
{
    public class Post : Entity
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}