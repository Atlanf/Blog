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
        private IMapper _mapper { get; init; }
        private IUserProjectRepository _userProjectRepository { get; init; }
        private IUserRepository _userRepository { get; init; }

        public UserProjectService(
            IMapper mapper,
            IUserProjectRepository userProjectRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userProjectRepository = userProjectRepository;
            _userRepository = userRepository;
        }

        public async Task<IList<PreviewActiveUserProjectsDTO>> GetActiveUserProjectsAsync(string userName, PageInfo page)
        {
            var userId = await _userRepository.GetUserIdAsync(userName, null);
            var result = new List<PreviewActiveUserProjectsDTO>();

            if (userId != "")
            {
                if (page.Page <= 0)
                {
                    page.Page = 1;
                }

                var userProjects = await _userProjectRepository.GetActiveUserProjectsAsync(userId, page);
                result = _mapper.Map<List<PreviewActiveUserProjectsDTO>>(userProjects);
                
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].PriorityRatio = PriorityRatioCalculator.SetPriorityRatio(userProjects[i]);
                }
            }

            return result.OrderByDescending(r => r.PriorityRatio).ToList();
        }
    }
}
