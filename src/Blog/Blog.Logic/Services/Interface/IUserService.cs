using Blog.Domain.Model.User;
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
    }
}
