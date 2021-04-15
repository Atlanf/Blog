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
        [HttpGet("{projectId}")]
        public async Task<ActionResult<List<UserTaskResponse>>> GetUserTasks(int projectId)
        {
            /* Temp value */
            string userName = "admin";

            var result = await _userTaskService.GetActiveProjectTasksAsync(projectId, userName);

            if (result != null)
            {
                return Ok(result);
            }

            return Problem(
                title: "Unauthorized access",
                detail: "You can not see details unless it is your project.",
                statusCode: 403
            );
        }
    }
}
