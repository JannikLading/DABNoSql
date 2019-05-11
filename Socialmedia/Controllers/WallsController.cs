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
    public class WallsController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly CircleService _circleService;

        public WallsController(UserService userService, CircleService circleService)
        {
            _userService = userService;
            _circleService = circleService;
        }

        [HttpGet("{userId}/{guestId}")]
        public ActionResult<List<Post>> Get(string userId, string guestId)
        {
            List<Post> postsToWall = new List<Post>();
            User user = _userService.Get(userId);
            User guestUser = _userService.Get(guestId);

            foreach (var id in user.BlockedUserId)
            {
                if (guestId == id)
                    return NoContent(); 
            }

            foreach (var post in user.Post)
            {
                postsToWall.Add(post);
            }
            
            List<string> circleIdList = new List<string>();
        private readonly UserService _userService;
        private readonly CircleService _circleService;

            foreach (var circleId in user.CircleId)
            {
                foreach (var circleIdOther in guestUser.CircleId)
                {
                    if (circleId == circleIdOther)
                    {
                        circleIdList.Add(circleId);
                    }
                }
            }
        public WallsController(UserService userService, CircleService circleService)
        {
            _userService = userService;
            _circleService = circleService;
        }

        [HttpGet("user_id, guest_id")]
        public ActionResult<List<Post>> Get(string user_id, string guest_id)
        {
            var user = _userService.Get(user_id);

            foreach (var i in user.FollowUserId)
            {
                if (i == guest_id)
                    return NotFound();
            }

            List<Post> Posts = new List<Post>();
            var guestUser = _userService.Get(guest_id);

            foreach (var i in user.Post)
            {
                Posts.Add(i);
            }

            foreach (var i in user.CircleId)
            {
                foreach (var j in guestUser.CircleId)
                {
                    if (j==i)
                    {
                        var circle = _circleService.Get(i);
                        foreach (var var in circle.Post)
                        {
                            if (var.UserId==user.Id)
                                Posts.Add(var);
                        }
                    }
                }
            }
            return Posts;
            foreach (var circleId in circleIdList)
            {
                Circle circle = _circleService.Get(circleId);

                foreach (var post in circle.Post)
                {
                    if (post.UserId == userId)
                    {
                        postsToWall.Add(post);
                    }
                }
            }

            return postsToWall;
        }
    }
}