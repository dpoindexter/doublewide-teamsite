﻿using System;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Blog;
using Doublewide.Domain.Enums;

namespace Doublewide.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IPostRepository _postRepository;

        public BlogService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post GetPostById(int id)
        {
            return _postRepository.Get(id);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> GetAllPosts(PostStatus status)
        {
            switch (status)
            {
                case PostStatus.Unpublished:
                    return _postRepository.GetUnpublished();
                default:
                    return _postRepository.GetPublished();
            }
        }

        public IEnumerable<Post> GetPostsByDateRange(DateTime rangeStart, DateTime rangeEnd)
        {
            return _postRepository.GetInDateRange(rangeStart, rangeEnd);
        }

        public IEnumerable<Post> GetLastNPosts(int limit)
        {
            return _postRepository.GetLastNPosts(limit);
        }
    }
}