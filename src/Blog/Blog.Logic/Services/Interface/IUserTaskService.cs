using Blog.Data.Model;
using Blog.Domain.Model.UserTask.Requests;
using Blog.Domain.Model.UserTask.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Interface
{
    public interface IUserTaskService
    {
        Task<List<UserTaskResponse>> CreateUserTaskAsync(CreateUserTaskRequest userTask);
        Task<List<UserTaskResponse>> GetActiveProjectTasksAsync(int projectId, string userName);
    }
}
