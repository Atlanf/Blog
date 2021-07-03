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
            return new List<UserTaskResponse>();
            //var taskToAdd = _mapper.Map<UserTask>(userTask);
            //taskToAdd.Project = await _userProjectRepository.GetUserProjectByIdAsync(userTask.ProjectId);

            //var operationResult = await _userTaskRepository.AddUserTaskAsync(taskToAdd);

            //if (operationResult != null)
            //{
            //    return _mapper.Map<List<UserTaskResponse>>(await GetProjectTasksAsync(userTask.ProjectId));
            //}
            //else
            //{
            //    _logger.LogWarning("CreateUserTaskAsync: Task was not added.", userTask);
            //    return null;
            //}
        }

        public async Task<List<UserTaskResponse>> GetActiveProjectTasksAsync(string projectShortName, string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var project = await _userProjectRepository.GetUserProjectByShortNameAsync(projectShortName, user.Id);
            var isOwner = await _userProjectRepository.UserIsOwnerAsync(project.Id, user.Id);

            if (isOwner)
            {
                if (!project.IsActive)
                {
                    _logger.LogInformation("GetActiveProjectTasksAsync User {@userName} tried to get access to an inactive project {@projectName}.", userName, projectShortName);
                    return new List<UserTaskResponse>()
                    {
                        new UserTaskResponse()
                        {
                            IsSuccess = true,
                            Errors = new List<string>()
                            {
                                "Project is inactive."
                            }
                        }
                    };
                }

                return _mapper.Map<List<UserTaskResponse>>(await GetProjectTasksAsync(projectShortName));
            }
            else
            {
                _logger.LogInformation("GetActiveProjectTasksAsync User {@userName} tried to get access to project {@projectName} They don't own the project.", userName, projectShortName);
                
                return new List<UserTaskResponse>()
                {
                    new UserTaskResponse()
                    {
                        IsSuccess = false,
                        Errors = new List<string>()
                        {
                            "You don't own this project."
                        }
                    }
                };
            }
        }

        private async Task<List<UserTask>> GetProjectTasksAsync(string projectShortName)
        {
            var result = await _userTaskRepository.GetAllProjectTasksAsync(projectShortName);

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
