using Blog.Logic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
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
        private IUserProjectService _userProjectService { get; init; }
        public UserProjectController(IUserProjectService userProjectService)
        {
            _userProjectService = userProjectService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
