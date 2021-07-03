using Blog.Domain.Model.UserTask.Responses;
using Blog.Logic.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly UserTaskService _userTaskService;
        public UserTaskController(UserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        //[Authorize]
        [HttpGet("{projectShortName}")]
        public async Task<ActionResult<List<UserTaskResponse>>> GetUserTasks(string projectShortName)
        {
            /* Temp value */
            string userName = "admin";

            var result = await _userTaskService.GetActiveProjectTasksAsync(projectShortName, userName);

            if (result.First().IsSuccess)
            {
                return Ok(result);
            }

            return Problem(
                title: "Access forbidden.",
                detail: "You can not see details unless it is your project.",
                statusCode: 403
            );
        }
    }
}
