using AutoMapper;
using Blog.Data.Model;
using Blog.Domain.Model.Enum;
using Blog.Domain.Model.UserTask.Requests;
using Blog.Domain.Model.UserTask.Responses;
using Blog.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Profiles
{
    public class UserTaskProfile : Profile
    {
        public UserTaskProfile()
        {
            CreateMap<CreateUserTaskRequest, UserTask>()
                .ForMember(t => t.PriorityId, opt => opt.MapFrom(ut =>
                    StringToEnumConverter<UserTaskPriorityTags>.Convert(ut.PriorityTag)))
                .ForMember(t => t.Project, opt => opt.Ignore());

            CreateMap<UserTask, UserTaskResponse>()
                .ForMember(t => t.Priority, opt => opt.MapFrom(ut => ut.Priority.Id));
        }
    }
}
