using Blog.Data.Repository.Interface;
using Blog.Logic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Implementation
{
    public class UserPostService : IUserPostService
    {
        private readonly IUserPostRepository _userPostRepository;

        public UserPostService(IUserPostRepository userPostRepository)
        {
            _userPostRepository = userPostRepository;
        }


    }
}
