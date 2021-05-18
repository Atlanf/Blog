using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject.Requests;
using Blog.Logic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectController : Controller
    {
        private readonly IUserProjectService _userProjectService;
        private readonly ILogger<UserProjectController> _logger;
        public UserProjectController(IUserProjectService userProjectService, ILogger<UserProjectController> logger)
        {
            _userProjectService = userProjectService;
            _logger = logger;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateNewProjectAsync(CreateUserProjectRequest project)
        {
            var result = await _userProjectService.CreateProjectAsync(project, "admin");
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{userName}/all")]
        public async Task<IActionResult> GetUserProjectsAsync(string userName, [FromQuery]PageInfo page)
        {
            var result = await _userProjectService.GetActiveUserProjectsAsync(userName, page);

            return Ok(result);
        }
    }
}
