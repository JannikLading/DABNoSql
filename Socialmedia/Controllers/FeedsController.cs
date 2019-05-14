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
        private readonly CircleService _circleService;
        private readonly PostsService _postsService;

        public FeedsController(UserService userService, CircleService circleService, PostsService postsService)
        {
            _userService = userService;
            _circleService = circleService;
            _postsService = postsService; 
        }

        [HttpGet("{id}")]
        public ActionResult<List<Post>> Get(string id)
        {
            List<Post> postsInFeed=new List<Post>();
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            foreach (var postId in user.PostId)
            {
                postsInFeed.Add(_postsService.Get(postId));
            }

            if (user.CircleId != null)
            {
                foreach (var circleId in user.CircleId)
                {
                    var Circle = _circleService.Get(circleId);
                    foreach (var postId in Circle.PostId)
                    {
                        postsInFeed.Add(_postsService.Get(postId));
                    }
                }
            }

            if (user.FollowUserId != null)
            {
                foreach (var followUserId in user.FollowUserId)
                {
                    var User = _userService.Get(followUserId);
                    foreach (var postId in User.PostId)
                    {
                        postsInFeed.Add(_postsService.Get(postId));
                    }
                }
            }

            return postsInFeed;
        }
    }
}