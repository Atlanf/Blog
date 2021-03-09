using Blog.Domain.Model.UserProject.Requests;
using Blog.Logic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        private readonly ILogger _logger;
        public UserProjectController(IUserProjectService userProjectService, ILogger logger)
        {
            _userProjectService = userProjectService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateNewProjectAsync(CreateUserProjectRequest project)
        {
            return Ok();
        }
    }
}
