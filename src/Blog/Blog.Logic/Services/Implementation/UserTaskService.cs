using AutoMapper;
using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Blog.Data.Repository.Interface;
using Blog.Domain.Model.Enum;
using Blog.Domain.Model.UserTask.Requests;
using Blog.Domain.Model.UserTask.Responses;
using Blog.Logic.Helpers;
using Blog.Logic.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Implementation
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IMapper _mapper;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserTaskService> _logger;

        public UserTaskService(
            IMapper mapper,
            IUserProjectRepository userProjectRepository,
            IUserTaskRepository userTaskRepository,
            IUserRepository userRepository,
            ILogger<UserTaskService> logger)
        {
            _mapper = mapper;
            _userTaskRepository = userTaskRepository;
            _userRepository = userRepository;
            _logger = logger;
            _userProjectRepository = userProjectRepository;
        }

        public async Task<List<UserTaskResponse>> CreateUserTaskAsync(CreateUserTaskRequest userTask)
        {
            var taskToAdd = _mapper.Map<UserTask>(userTask);
            taskToAdd.Project = await _userProjectRepository.GetUserProjectByIdAsync(userTask.ProjectId);

            var operationResult = await _userTaskRepository.AddUserTaskAsync(taskToAdd);

            if (operationResult != null)
            {
                return _mapper.Map<List<UserTaskResponse>>(await GetProjectTasks(userTask.ProjectId));
            }
            else
            {
                _logger.LogWarning("CreateUserTaskAsync: Task was not added.", userTask);
                return null;
            }
        }

        public async Task<List<UserTaskResponse>> GetActiveProjectTasks(int projectId, string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var owner = await _userProjectRepository.UserIsOwnerAsync(projectId, user.Id);

            if (owner)
            {
                return _mapper.Map<List<UserTaskResponse>>(await GetProjectTasks(projectId));
            }
            else
            {
                return null;
            }
        }

        private async Task<List<UserTask>> GetProjectTasks(int projectId)
        {
            var result = await _userTaskRepository.GetAllProjectTasksAsync(projectId);

            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<UserTask>();
            }
        }
    }
}
