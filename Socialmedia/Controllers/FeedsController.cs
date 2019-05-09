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
    public class FeedsController : ControllerBase
    {
        private readonly UserService _userService;

        public FeedsController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Post>> Get(string id)
        {
            List<Post> postsInFeed=new List<Post>();
            User user = _userService.Get(id);
            if (user.Post == null)
            {
                return NotFound();
            }
            foreach (var i in user.Post)
            {
                postsInFeed.Add(i);
            }

            return postsInFeed;
        }
    }
}