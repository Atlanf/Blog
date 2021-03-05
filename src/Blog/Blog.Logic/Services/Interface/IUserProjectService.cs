using Blog.Domain;
using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Services.Interface
{
    public interface IUserProjectService
    {
        Task<IList<ActiveUserProjectsPreview>> GetActiveUserProjectsAsync(string userName, PageInfo page);
    }
}
