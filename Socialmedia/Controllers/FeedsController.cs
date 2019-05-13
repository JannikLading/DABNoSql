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

        public FeedsController(UserService userService, CircleService circleService)
        {
            _userService = userService;
            _circleService = circleService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Post>> Get(string id)
        {
            List<Post> postsInFeed=new List<Post>();
            var user = _userService.Get(id);

            if (user.Post == null)
            {
                return NotFound();
            }

            foreach (var i in user.Post)
            {
                //postsInFeed.Add(i);
            }

            if (user.CircleId == null)
            {
                return NotFound();
            }

            foreach (var i in user.CircleId)
            {
                var Circle = _circleService.Get(i);
                foreach (var j in Circle.Post)
                {
                    //postsInFeed.Add(j);
                }
            }

            if (user.FollowUserId == null)
            {
                return NotFound();
            }

            foreach (var i in user.FollowUserId)
            {
                var User = _userService.Get(i);
                foreach (var j in User.Post)
                {
                    //postsInFeed.Add(j);
                }
            }

            return postsInFeed;
        }
    }
}