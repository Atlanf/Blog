using AutoMapper;
using Blog.Data.Model;
using Blog.Domain.Model.User;
using Blog.Domain.Model.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignupRequest, User>();
        }
    }
}
