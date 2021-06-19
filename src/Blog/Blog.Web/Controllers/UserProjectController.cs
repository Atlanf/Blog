using Blog.Domain.Model.Page;
using Blog.Domain.Model.UserProject.Requests;
using Blog.Domain.Model.UserProject.Responses;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewProjectAsync(CreateUserProjectRequest project)
        {
            // Change "admin" to actual user 
            var result = await _userProjectService.CreateProjectAsync(project, "admin");
            
            if (result.IsSuccess)
            {
                // Change to Redirect to Created Project Details
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpGet("{userName}/all")]
        public async Task<IActionResult> GetUserProjectsAsync(string userName, [FromQuery]PageInfo pageInfo)
        {
            var result = await _userProjectService.GetActiveUserProjectsAsync(userName, pageInfo);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
