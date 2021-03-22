using AutoMapper;
using Blog.Data.Repository.Interface;
using Blog.Domain.Model.UserTask.Requests;
using Blog.Domain.Model.UserTask.Responses;
using Blog.Logic.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Implementation
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IMapper _mapper;
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserTaskService> _logger;

        public UserTaskService(
            IMapper mapper,
            IUserTaskRepository userTaskRepository,
            IUserRepository userRepository,
            ILogger<UserTaskService> logger)
        {
            _mapper = mapper;
            _userTaskRepository = userTaskRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserTaskListResponse> CreateUserTaskAsync(CreateUserTaskRequest userTask)
        {


            return null;
        }
    }
}
