using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly AppDbContext _context;
        public UserTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> AddUserTaskAsync(UserTask newUserTask)
        {
            await _context.AddAsync(newUserTask);
            await _context.SaveChangesAsync();

            return _context.UserTasks.FindAsync(newUserTask).Result;
        }

        public async Task<UserTask> UpdateUserTaskAsync(UserTask updatedUserTask)
        {
            _context.Entry(updatedUserTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _context.UserTasks.FindAsync(updatedUserTask).Result;
        }
    }
}
