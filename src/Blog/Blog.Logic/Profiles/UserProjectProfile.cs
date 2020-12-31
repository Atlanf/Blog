using AutoMapper;
using Blog.Data.Helpers;
using Blog.Data.Model;
using Blog.Domain.Model.UserProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Profiles
{
    public class UserProjectProfile : Profile
    {
        public UserProjectProfile()
        {
            CreateMap<UserProject, PreviewActiveUserProjectsDTO>()
                .ForMember(proj => proj.UserProjectId, opt => opt.MapFrom(x => x.Id))
                .ForMember(proj => proj.ProjectTitle, opt => opt.MapFrom(x => x.Title))
                .ForMember(
                    proj => proj.UnfinishedTaskCount,
                    opt => opt.MapFrom(x => x.UserTasks
                        .Where(t => t.IsComplete == false)
                        .Count())
                 )
                .ForMember(
                    proj => proj.LastFinishedTask,
                    opt => opt.MapFrom(t => t.UserTasks
                        .OrderByDescending(d => d.DateCompleted)
                        .FirstOrDefault()
                        .DateCompleted
                    )
                )
                .ForMember(
                    proj => proj.HighPriorityTaskCount,
                    opt => opt.MapFrom(x => x.UserTasks
                        .Where(t => t.Priority.Id == UserTaskPriorities.High)
                        .Count()
                    )
                )
                .ForMember(proj => proj.PriorityRatio, opt => opt.Ignore());
        }
    }
}
