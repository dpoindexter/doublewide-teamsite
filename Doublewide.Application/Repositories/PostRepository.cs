using System;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        public PostRepository(IDbConnectionFactory connectionFactory) 
            : base(connectionFactory)
        {
        }

        public IEnumerable<Post> GetAll(PostStatus status)
        {
            var statusPredicate = BuildStatusPredicate(status);

            IEnumerable<Post> posts;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                posts = db.Select<Post>(p => p.Published == statusPredicate);
            }
            return posts;
        }

        public IEnumerable<Post> GetAll(DateTime rangeStart, DateTime rangeEnd)
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

        private static bool BuildStatusPredicate(PostStatus status)
        {
            switch (status)
            {
                case PostStatus.Published:
                    return true;
                default:
                    return false;
            }            
        }
    }
}