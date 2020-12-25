using Blog.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    interface IUserTaskRepository
    {
        Task<UserTask> AddUserTaskAsync(UserTask newUserTask);
        Task<UserTask> UpdateUserTaskAsync(UserTask updatedUserTask);

    }
}
