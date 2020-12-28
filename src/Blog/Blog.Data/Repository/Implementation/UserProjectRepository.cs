using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            return await _context.UserProjects.FindAsync(newUserProject);
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
    }
}
