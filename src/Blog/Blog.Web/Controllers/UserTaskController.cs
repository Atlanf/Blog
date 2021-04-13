using Blog.Logic.Services.Implementation;
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


    }
}
