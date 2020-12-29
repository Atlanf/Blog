using Blog.Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserAsync(User newUser, string password);
        Task<User> GetUserByNameAsync(string userName);
        Task<User> GetUserByEmailAsync(string userEmail);
    }
}
