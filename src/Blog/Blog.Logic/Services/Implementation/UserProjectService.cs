using AutoMapper;
using Blog.Data.Repository.Interface;
using Blog.Domain;
using Blog.Domain.Model.UserProject;
using Blog.Logic.Helpers;
using Blog.Logic.Services.Interface;
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

        public UserProjectService(
            IMapper mapper,
            IUserProjectRepository userProjectRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userProjectRepository = userProjectRepository;
            _userRepository = userRepository;
        }

        public async Task<IList<ActiveUserProjectsPreview>> GetActiveUserProjectsAsync(string userName, PageInfo page)
        {
            var userId = await _userRepository.GetUserIdAsync(userName, null);
            var result = new List<ActiveUserProjectsPreview>();

            if (userId != "")
            {
                if (page.Page <= 0)
                {
                    page.Page = 1;
                }

                var userProjects = await _userProjectRepository.GetActiveUserProjectsAsync(userId, page);
                result = _mapper.Map<List<ActiveUserProjectsPreview>>(userProjects);
                
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].PriorityRatio = PriorityRatioCalculator.SetPriorityRatio(userProjects[i]);
                }
            }

            return result.OrderByDescending(r => r.PriorityRatio).ToList();
        }
    }
}
