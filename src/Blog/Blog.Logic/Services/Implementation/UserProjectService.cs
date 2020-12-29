using AutoMapper;
using Blog.Data.Repository.Interface;
using Blog.Logic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Logic.Services.Implementation
{
    public class UserProjectService : IUserProjectService
    {
        private IMapper _mapper { get; init; }
        private IUserProjectRepository _userProjectRepository { get; init; }
        public UserProjectService(IMapper mapper, IUserProjectRepository userProjectRepository)
        {
            _mapper = mapper;
            _userProjectRepository = userProjectRepository;
        }
    }
}
