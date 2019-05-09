using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialmedia.Models;
using Socialmedia.Services;

namespace Socialmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly PostsService _postsService;

        public FeedsController(UserService userService, PostsService postsService)
        {
            _userService = userService;
            _postsService = postsService;
        }

        [HttpGet("{id")]
        public ActionResult<List<Post>> Get(string userId)
        {
            List<Post> postsInFeed=new List<Post>();
            User user = _userService.Get(userId);
            foreach (var i in user.Post)
            {
                postsInFeed.Add(i);
            }

            return postsInFeed;
        }
    }
}