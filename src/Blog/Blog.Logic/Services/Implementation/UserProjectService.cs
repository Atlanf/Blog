using AutoMapper;
using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Blog.Domain;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject;
using Blog.Domain.Model.UserProject.Requests;
using Blog.Domain.Model.UserProject.Responses;
using Blog.Logic.Helpers;
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

        public async Task<IList<ActiveUserProjectsPreviewResponse>> GetActiveUserProjectsAsync(string userName, PageInfo page)
        {
            var userId = await _userRepository.GetUserIdByNameAsync(userName);
            var result = new List<ActiveUserProjectsPreviewResponse>();

            if (userId != "")
            {
                page = PageVerificator.AdjustPage(page);

                var userProjects = await _userProjectRepository.GetActiveUserProjectsAsync(userId, page);
                result = _mapper.Map<List<ActiveUserProjectsPreviewResponse>>(userProjects);
                
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].PriorityRatio = PriorityRatioCalculator.SetPriorityRatio(userProjects[i]);
                }
            }

            return result.OrderByDescending(r => r.PriorityRatio).ToList();
        }

        public async Task<UserProjectDetailsResponse> CreateProjectAsync(CreateUserProjectRequest projectToCreate,
            string userName)
        {
            var user = await _userRepository.GetUserIdByNameAsync(userName);
            if (!(await _userProjectRepository.IsUserProjectExistsAsync(projectToCreate.Title, user)))
            {
                var projectToAdd = _mapper.Map<UserProject>(projectToCreate);
                projectToAdd.User = await _userRepository.GetUserByNameAsync(userName);

                var result = await _userProjectRepository.AddUserProjectAsync(projectToAdd);

                if (result != null)
                {
                    return _mapper.Map<UserProjectDetailsResponse>(result);
                }
                else
                {
                    _logger.LogWarning("CreateProjectAsync result is NULL. ", projectToCreate, projectToAdd.User);
                    return null;
                }
            }
            else
            {
                _logger.LogInformation("CreateProjectAsync project with these credentials for this user already exists. Project: {@ProjectToCreate}; User: {@UserName}", projectToCreate, userName);
                return null;
            }
        }
    }
}
