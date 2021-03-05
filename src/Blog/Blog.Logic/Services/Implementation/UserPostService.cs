using AutoMapper;
using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Blog.Domain;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserPost;
using Blog.Domain.Model.UserPost.Requests;
using Blog.Domain.Model.UserPost.Responses;
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
        private readonly IMapper _mapper;
        private readonly IUserPostRepository _userPostRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStoredFileRepository _storedFileRepository;

        public UserPostService(
            IMapper mapper,
            IUserPostRepository userPostRepository,
            IUserRepository userRepository,
            IStoredFileRepository storedFileRepository)
        {
            _userPostRepository = userPostRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _storedFileRepository = storedFileRepository;
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
            var post = _mapper.Map<UserPost>(newPost);
            post.User = await _userRepository.GetUserByNameAsync(newPost.UserName);
            post.PostTags = await _userPostRepository.GetPostTagsAsync(newPost.SelectedTags);
            post.AttachedFiles = await _storedFileRepository.GetFilesByUniqueNameAsync(newPost.AttachedFiles);

            var result = await _userPostRepository.AddUserPostAsync(post);

            /* Change later */
            if (result != null)
            {
                return new UserPostDetails() { IsAdded = true };
            }
            else
            {
                return new UserPostDetails() { IsAdded = false };
            }
        }
    }
}
