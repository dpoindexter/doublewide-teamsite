using System;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Blog;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        public PostRepository(IDbConnectionFactory connectionFactory) 
            : base(connectionFactory)
        {
        }

        public IEnumerable<Post> GetPublished()
        {
            IEnumerable<Post> posts;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                posts = db.Select<Post>(@"SELECT * FROM Post WHERE Published = 1 ORDER BY Timestamp DESC");
            }
            return posts;
        }

        public IEnumerable<Post> GetUnpublished()
        {
            IEnumerable<Post> posts;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                posts = db.Select<Post>(@"SELECT * FROM Post WHERE Published = 1 ORDER BY Timestamp DESC");
            }
            return posts;
        }

        public IEnumerable<Post> GetInDateRange(DateTime rangeStart, DateTime rangeEnd)
        {
            IEnumerable<Post> posts;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                posts = db.Select<Post>(p => p.Timestamp >= rangeStart && p.Timestamp <= rangeEnd);
            }
            return posts;
        }

        public IEnumerable<Post> GetLastNPosts(int limit)
        {
            IEnumerable<Post> posts;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                posts = db.Select<Post>(@"SELECT TOP {0} * FROM Post ORDER BY Timestamp DESC", limit);
            }
            return posts;
        }
    }
}