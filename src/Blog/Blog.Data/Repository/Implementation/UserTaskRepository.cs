using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Blog.Data.Repository.Implementation
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private AppDbContext _context { get; init; }

        public UserTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> AddUserTaskAsync(UserTask newUserTask)
        {
            await _context.UserTasks.AddAsync(newUserTask);
            await _context.SaveChangesAsync();

            return await _context.UserTasks.FindAsync(newUserTask);
        }

        public async Task<UserTask> UpdateUserTaskAsync(UserTask userTaskToUpdate)
        {
            _context.Entry(userTaskToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.UserTasks.FindAsync(userTaskToUpdate);
        }

        public async Task<UserTask> DeleteUserTaskAsync(UserTask taskToDelete, bool softDelete)
        {
            if (softDelete)
            {
                taskToDelete.IsDeleted = true;
                _context.Entry(taskToDelete).State = EntityState.Modified;
            }
            else
            {
                _context.UserTasks.Remove(taskToDelete);
            }
            await _context.SaveChangesAsync();

            return await _context.UserTasks.FindAsync(taskToDelete);
        }
    }
}
