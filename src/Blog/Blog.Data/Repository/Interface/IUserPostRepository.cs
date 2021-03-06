﻿using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IUserPostRepository
    {
        Task<UserPost> AddUserPostAsync(UserPost newUserPost);
        Task<UserPost> UpdateUserPostAsync(UserPost userPostToUpdate);
        Task<UserPost> DeleteUserPostAsync(UserPost userPostToDelete, bool softDelete);
        Task<List<PostTag>> GetPostTagsAsync(IList<PostTags> postTags);
    }
}
