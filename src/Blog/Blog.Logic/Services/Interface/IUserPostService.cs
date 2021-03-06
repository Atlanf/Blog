﻿using Blog.Domain;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserPost;
using Blog.Domain.Model.UserPost.Requests;
using Blog.Domain.Model.UserPost.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Interface
{
    public interface IUserPostService
    {
        Task<IList<UserPostsPreview>> GetUserPostsPreviewAsync(string userId, PageInfo page);
        Task<IList<LastPostsPreview>> GetLastPostsPreviewAsync(PageInfo page);
        Task<UserPostDetailsResponse> CreatePostAsync(CreatePostRequest newPost);
    }
}
