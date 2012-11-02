using System;
using System.Collections.Generic;
using Doublewide.Domain.Blog;

namespace Doublewide.Application.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post, int>
    {
        IEnumerable<Post> GetPublished();
        IEnumerable<Post> GetUnpublished();
        IEnumerable<Post> GetInDateRange(DateTime rangeStart, DateTime rangeEnd);
        IEnumerable<Post> GetLastNPosts(int limit);
    }
}
