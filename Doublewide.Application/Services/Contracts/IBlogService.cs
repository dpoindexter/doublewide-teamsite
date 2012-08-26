using System;
using System.Collections.Generic;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;

namespace Doublewide.Application.Services.Contracts
{
    public interface IBlogService
    {
        Post GetPostById(int id);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetAllPosts(PostStatus status);
        IEnumerable<Post> GetPostsByDateRange(DateTime rangeStart, DateTime rangeEnd);
        IEnumerable<Post> GetLastNPosts(int limit);
    }
}
