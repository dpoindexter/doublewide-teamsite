using System;
using System.Collections.Generic;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;

namespace Doublewide.Application.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post, int>
    {
        IEnumerable<Post> GetAll(PostStatus status);
        IEnumerable<Post> GetAll(DateTime rangeStart, DateTime rangeEnd);
        IEnumerable<Post> GetLastNPosts(int limit);
    }
}
