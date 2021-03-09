using AutoMapper;
using Blog.Data.Model;
using Blog.Domain.Model.UserPost;
using Blog.Domain.Model.UserPost.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Profiles
{
    public class UserPostProfile : Profile
    {
        public UserPostProfile()
        {
            CreateMap<CreatePostRequest, UserPost>()
                .ForMember(post => post.DatePosted, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(post => post.PostTags, opt => opt.Ignore())
                .ForMember(post => post.AttachedFiles, opt => opt.Ignore())
                .ForMember(post => post.User, opt => opt.Ignore());
        }
    }
}
