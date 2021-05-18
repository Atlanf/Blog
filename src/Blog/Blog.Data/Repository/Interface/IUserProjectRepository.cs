using Blog.Data.Model;
using Blog.Domain;
using Blog.Domain.Model.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IUserProjectRepository
    {
        Task<UserProject> AddUserProjectAsync(UserProject newUserProject);
        Task<UserProject> UpdateUserProjectAsync(UserProject userProjectToUpdate);
        Task<UserProject> DeleteUserProjectAsync(UserProject userProjectToDelete, bool softDelete);
        Task<IList<UserProject>> GetActiveUserProjectsAsync(string userId, PageInfo page);
        Task<UserProject> GetUserProjectByIdAsync(int projectId);
        Task<bool> IsUserProjectExistsAsync(string title, string userId);
        Task<bool> UserIsOwnerAsync(int projectId, string userId);
        Task<int> GetActiveUserProjectsCountAsync(string userId);
    }
}
