using Blog.Data.Repository.Interface;
using Blog.Logic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.Model.User;
using Blog.Data.Model;
using Blog.Domain.Model.User.Requests;
using Blog.Domain.Model.User.Responses;

namespace Blog.Logic.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<SignupResponse> SignupUser(SignupRequest request)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userRepository.AddUserAsync(user, request.Password);

            if (result.Succeeded)
            {
                return new SignupResponse() { Successful = true };
            }
            else
            {
                return new SignupResponse()
                {
                    Successful = false,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }
        }
    }
}
