using Blog.Domain.Model.User;
using Blog.Domain.Model.User.Requests;
using Blog.Domain.Model.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Interface
{
    public interface IUserService
    {
        Task<SignupResponse> SignupUser(SignupRequest request);
        Task<SigninResponse> SigninUser(SigninRequest request);
    }
}
