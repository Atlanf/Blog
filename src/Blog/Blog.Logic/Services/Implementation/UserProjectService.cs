using AutoMapper;
using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Blog.Domain;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject;
using Blog.Domain.Model.UserProject.Requests;
using Blog.Domain.Model.UserProject.Responses;
using Blog.Logic.Helpers;
using Blog.Logic.Helpers.ServiceHelpers;
using Blog.Logic.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Implementation
{
    public class UserProjectService : IUserProjectService
    {
        private readonly IMapper _mapper;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserProjectService> _logger;

        public UserProjectService(
            IMapper mapper,
            IUserProjectRepository userProjectRepository,
            IUserRepository userRepository,
            ILogger<UserProjectService> logger)
        {
            _mapper = mapper;
            _userProjectRepository = userProjectRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<ActiveUserProjectsPreviewResponse>> GetActiveUserProjectsAsync(
            string userName,
            PageInfo page)
        {
            var result = new PaginatedList<ActiveUserProjectsPreviewResponse>();

            var userId = await _userRepository.GetUserIdByNameAsync(userName);
            
            if (userId != "")
            {
                page = PageVerificator.AdjustPage(page);

                var userProjects = await _userProjectRepository.GetActiveUserProjectsAsync(userId, page);
                var projectsCount = await _userProjectRepository.GetActiveUserProjectsCountAsync(userId);

                result = UserProjectHelper.AssignActiveUserProjectValues(userProjects, page, projectsCount, _mapper);
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.Add("You can not view these projects.");
                _logger.LogInformation("GetActiveUserProjectsAsync user was not found. ", userName);
            }

            return result;
        }

        public async Task<UserProjectDetailsResponse> CreateProjectAsync(
            CreateUserProjectRequest projectToCreate,
            string userName)
        {
            var result = new UserProjectDetailsResponse();
            var user = await _userRepository.GetUserIdByNameAsync(userName);
            if (!(await _userProjectRepository.IsUserProjectExistsAsync(projectToCreate.Title, user)))
            {
                var projectToAdd = _mapper.Map<UserProject>(projectToCreate);
                projectToAdd.User = await _userRepository.GetUserByNameAsync(userName);

                var operationResult = await _userProjectRepository.AddUserProjectAsync(projectToAdd);

                if (operationResult != null)
                {
                    return _mapper.Map<UserProjectDetailsResponse>(operationResult);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Something went wrong on creating new project.");
                    _logger.LogWarning("CreateProjectAsync result is NULL. ", projectToCreate, projectToAdd.User);
                    return result;
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.Add("Project with such name already exists or active. ");
                _logger.LogInformation("CreateProjectAsync project with these credentials for this user already exists. Project: {@ProjectToCreate}; User: {@UserName}", projectToCreate, userName);
                return result;
            }
        }
    }
}
