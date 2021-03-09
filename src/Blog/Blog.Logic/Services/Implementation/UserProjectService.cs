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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Blog.Logic.Services.Implementation
{
    public class UserProjectService : IUserProjectService
    {
        private readonly IMapper _mapper;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public UserProjectService(
            IMapper mapper,
            IUserProjectRepository userProjectRepository,
            IUserRepository userRepository,
            ILogger logger)
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
            if (!_userProjectRepository.IsUserProjectExists(projectToCreate.Title, projectToCreate.Description, user))
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
                    _logger.Warning("CreateProjectAsync result is NULL. ", projectToCreate, projectToAdd.User);
                    return new UserProjectDetailsResponse()
                    {
                        IsError = true,
                        AdditionalInfo = "Something happened on creating new project."
                    };
                }
            }
            else
            {
                _logger.Warning("CreateProjectAsync project with these credentials for this user already exists ", userName);
                return new UserProjectDetailsResponse()
                {
                    IsError = true,
                    AdditionalInfo = "You already have project with such title and description."
                };
            }
        }
    }
}
