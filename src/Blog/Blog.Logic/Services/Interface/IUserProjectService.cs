using Blog.Domain;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject;
using Blog.Domain.Model.UserProject.Requests;
using Blog.Domain.Model.UserProject.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Interface
{
    public interface IUserProjectService
    {
        Task<PaginatedList<ActiveUserProjectsPreviewResponse>> GetActiveUserProjectsAsync(string userName, PageInfo page);
        Task<CreateUserProjectResponse> CreateProjectAsync(CreateUserProjectRequest projectToCreate, string userName);
    }
}
