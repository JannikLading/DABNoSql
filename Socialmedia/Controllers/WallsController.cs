﻿using System;
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
            //User user = _userService.Get(userId);
            //User guestUser = _userService.Get(guestId);

            //foreach (var id in user.BlockedUserId)
            //{
            //    if (guestId == id)
            //        return NoContent(); 
            //}

            //foreach (var post in user.Post)
            //{
            //    //postsToWall.Add(post);
            //}
            
            //List<string> circleIdList = new List<string>();

            //foreach (var circleId in user.CircleId)
            //{
            //    foreach (var circleIdOther in guestUser.CircleId)
            //    {
            //        if (circleId == circleIdOther)
            //        {
            //            circleIdList.Add(circleId);
            //        }
            //    }
            //}
           
            //foreach (var circleId in circleIdList)
            //{
            //    Circle circle = _circleService.Get(circleId);

            //    foreach (var post in circle.Post)
            //    {
            //        if (post.UserId == userId)
            //        {
            //            postsToWall.Add(post);
            //        }
            //    }
            //}

            return postsToWall;
        }
    }
}