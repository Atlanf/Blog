using AutoMapper;
using Blog.Data.Model;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Helpers.ServiceHelpers
{
    internal static class UserProjectHelper
    {
        public static PaginatedList<ActiveUserProjectsPreviewResponse> AssignActiveUserProjectValues(
            IList<UserProject> projects,
            PageInfo page,
            int projectsCount,
            IMapper mapper)
        {
            var result = new PaginatedList<ActiveUserProjectsPreviewResponse>();

            var activeProjects = mapper.Map<List<ActiveUserProjectsPreviewResponse>>(projects);

            for (int i = 0; i < activeProjects.Count; i++)
            {
                if (projects[i].UserTasks.Count > 0)
                {
                    activeProjects[i].PriorityRatio = PriorityRatioCalculator.SetPriorityRatio(projects[i]);
                }
                else
                {
                    activeProjects[i].PriorityRatio = -1;
                }
            }

            result = PaginationHelper<ActiveUserProjectsPreviewResponse>.SetPaginatedList(activeProjects, page, projectsCount);
            result.Items.OrderByDescending(r => r.PriorityRatio).ToList();

            return result;
        }
    }
}
