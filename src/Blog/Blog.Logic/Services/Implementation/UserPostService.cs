using Blog.Data.Repository.Interface;
using Blog.Domain;
using Blog.Domain.Model.UserPost;
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

        public async Task<IList<UserPostsPreview>> GetUserPostsPreviewAsync(string userId, PageInfo page)
        {


            return new List<UserPostsPreview>();
        }

        public async Task<IList<LastPostsPreview>> GetLastPostsPreviewAsync(PageInfo page)
        {


            return new List<LastPostsPreview>();
        }

        public async Task<UserPostDetails> CreatePostAsync(CreatePostRequest newPost)
        {


            return new UserPostDetails();
        }
    }
}
