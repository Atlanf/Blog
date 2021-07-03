using Blog.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IUserTaskRepository
    {
        Task<UserTask> AddUserTaskAsync(UserTask newUserTask);
        Task<UserTask> UpdateUserTaskAsync(UserTask userTaskToUpdate);
        Task<UserTask> DeleteUserTaskAsync(UserTask taskToDelete, bool softDelete);
        Task<List<UserTask>> GetAllProjectTasksAsync(string projectShortName);
    }
}
