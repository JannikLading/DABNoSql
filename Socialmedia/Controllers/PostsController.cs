using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Socialmedia.Models;
using Socialmedia.Services;

namespace Socialmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly PostsService _postsService;
        private readonly CircleService _circleService;
        private readonly UserService _userService; 

        public PostsController(PostsService postsService, CircleService circleService, UserService userService)
        {
            _postsService = postsService;
            _circleService = circleService;
            _userService = userService; 
        }

        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return _postsService.Get();
        }

        // GET api/users/5
        [HttpGet("{id}", Name = "GetPost")]
        public ActionResult<Post> Get(string id)
        {
            var post = _postsService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Post> Create(Post post)
        {
            _postsService.Create(post);
            return CreatedAtRoute("GetPost", new {id = post.Id.ToString()}, post);
        }

        // POST api/<controller>
        [HttpPost("{userId}")]
        public ActionResult Create_Post(string userId, Post post)
        {
            _postsService.Create(post); 
            
            if (post.CircleId != null) // not tested 
            {
                var circle = _circleService.Get(post.CircleId);

                if (circle == null)
                    return NotFound();
                
                circle.PostId.Add(post.Id);
                _circleService.Update(circle); 
            }
            else
            {
                var user = _userService.Get(userId);

                if (user == null)
                    return NotFound();

                user.PostId.Add(post.Id);
                _userService.Update(user);
            }

            return NoContent(); 
        }

        //  api/<controller>/5
        [HttpPatch("{id}")]
        public ActionResult Create_Comment(string postId, Comment text) 
        {
           var post = _postsService.Get(postId);
        
           if (post == null)
            {
                return NotFound();
            }

            _postsService.CommentPost(postId, text.CommentText);

            return NoContent(); 
        }
    }
}
