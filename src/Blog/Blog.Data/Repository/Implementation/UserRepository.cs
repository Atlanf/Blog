using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserAsync(User newUser, string password)
        {
            return await _userManager.CreateAsync(newUser, password);
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<User> GetUserByEmailAsync(string userEmail)
        {
            return await _userManager.FindByEmailAsync(userEmail);
        }

        public async Task<string> GetUserIdByNameAsync(string name)
        {
            var userId = "";

            if (name != null)
            {
                userId = (await _userManager.FindByNameAsync(name)).Id;
            }

            return userId;
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            var userId = "";

            if (email != null)
            {
                userId = (await _userManager.FindByEmailAsync(email)).Id;
            }

            return userId;
        }

        public async Task<bool> IsUserExists(string userName)
        {
            return await _userManager.FindByNameAsync(userName) != null ? true : false;
        }
    }
}
