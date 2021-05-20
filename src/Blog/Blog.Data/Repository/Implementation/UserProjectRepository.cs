using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Blog.Domain;
using Blog.Domain.Model.Page;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly AppDbContext _context;

        public UserProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserProject> AddUserProjectAsync(UserProject newUserProject)
        {
            await _context.UserProjects.AddAsync(newUserProject);
            await _context.SaveChangesAsync();

            return await _context.UserProjects
                .FirstOrDefaultAsync(proj => proj.Title == newUserProject.Title && proj.UserId == newUserProject.User.Id && !proj.IsDeleted);
        }
        public async Task<UserProject> UpdateUserProjectAsync(UserProject userProjectToUpdate)
        {
            _context.Entry(userProjectToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.UserProjects.FindAsync(userProjectToUpdate);
        }

        public async Task<UserProject> DeleteUserProjectAsync(UserProject userProjectToDelete, bool softDelete)
        {
            if (softDelete)
            {
                userProjectToDelete.IsDeleted = true;
                _context.Entry(userProjectToDelete).State = EntityState.Modified;
            }
            else
            {
                _context.UserProjects.Remove(userProjectToDelete);
            }
            await _context.SaveChangesAsync();

            return await _context.UserProjects.FindAsync(userProjectToDelete);
        }

        public async Task<IList<UserProject>> GetActiveUserProjectsAsync(string userId, PageInfo page)
        {
            return await _context.UserProjects
                .Where(proj => proj.UserId == userId && proj.IsActive && !proj.IsHidden && !proj.IsDeleted && proj.Title.Contains(page.SearchRequest))
                .Skip((page.Page - 1) * page.PageSize)
                .Take(page.PageSize)
                .Where(proj => proj.Title.Contains(page.SearchRequest))
                .Include(proj => proj.UserTasks).ThenInclude(task => task.Priority)
                .ToListAsync();
        }

        public async Task<bool> IsUserProjectExistsAsync(string title, string userId)
        {
            return await _context.UserProjects
                .AnyAsync(proj => proj.Title.ToLower() == title.ToLower() && proj.UserId == userId && !proj.IsDeleted);
        }

        public async Task<UserProject> GetUserProjectByIdAsync(int projectId)
        {
            return await _context.UserProjects
                .FirstOrDefaultAsync(proj => proj.Id == projectId && !proj.IsDeleted);
        }

        public async Task<bool> UserIsOwnerAsync(int projectId, string userId)
        {
            return await _context.UserProjects
                .AnyAsync(proj => proj.Id == projectId && proj.UserId == userId && !proj.IsDeleted);
        }

        public async Task<int> GetActiveUserProjectsCountAsync(string userId)
        {
            return await _context.UserProjects
                .CountAsync(p => p.UserId == userId && p.IsActive && !p.IsDeleted);
        }
    }
}
