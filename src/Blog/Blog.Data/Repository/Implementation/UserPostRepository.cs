﻿using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Blog.Data.Repository.Interface;
using Blog.Domain.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class UserPostRepository : IUserPostRepository
    {
        private readonly AppDbContext _context;

        public UserPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserPost> AddUserPostAsync(UserPost newUserPost)
        {
            await _context.UserPosts.AddAsync(newUserPost);
            await _context.SaveChangesAsync();

            return await _context.UserPosts.FindAsync(newUserPost);
        }

        public async Task<UserPost> UpdateUserPostAsync(UserPost userPostToUpdate)
        {
            _context.Entry(userPostToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.UserPosts.FindAsync(userPostToUpdate);
        }

        public async Task<UserPost> DeleteUserPostAsync(UserPost userPostToDelete, bool softDelete)
        {
            if (softDelete)
            {
                userPostToDelete.IsDeleted = true;
                _context.Entry(userPostToDelete).State = EntityState.Modified;
            }
            else
            {
                _context.UserPosts.Remove(userPostToDelete);
            }
            await _context.SaveChangesAsync();

            return await _context.UserPosts.FindAsync(userPostToDelete);
        }

        public async Task<List<PostTag>> GetPostTagsAsync(IList<PostTags> postTags)
        {
            return await _context.PostTags
                .Where(tag => postTags.Any(id => id == tag.Id))
                .ToListAsync();
        }
    }
}
