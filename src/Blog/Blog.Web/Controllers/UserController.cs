using Blog.Domain.Model.User;
using Blog.Domain.Model.User.Requests;
using Blog.Domain.Model.User.Responses;
using Blog.Logic.Services.Interface;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<SignupResponse>> SignupUser([FromBody]SignupRequest request)
        {
            var result = await _userService.SignupUser(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return Problem();
            }
        }
    }
}
