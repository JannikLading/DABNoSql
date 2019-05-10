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

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
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
        [HttpPost("{id}")]
        public ActionResult<Post> Create(string id, Post post)
        {
            post.UserId = id;
            _postsService.Create(post);
            return CreatedAtRoute("GetPost", new {id = post.Id.ToString()}, post);
        }

        //  api/<controller>/5
        [HttpPatch("{id}")]
        public ActionResult Comment(string id, Comment text) 
        {
            var post = _postsService.Get(id);

           if (post == null)
            {
                return NotFound();
            }

            _postsService.CommentPost(id, text.CommentText);

            return NoContent(); 
        }
    }
}
