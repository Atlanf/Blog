using Blog.Domain.Model.UserPost;
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
    public class UserPostController : ControllerBase
    {
        private readonly IUserPostService _userPostService;
        public UserPostController(IUserPostService userPostService)
        {
            _userPostService = userPostService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserPostDetails>> CreatePostAsync(CreatePostRequest newPost)
        {
            var result = await _userPostService.CreatePostAsync(newPost);

            if (result.IsAdded)
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
