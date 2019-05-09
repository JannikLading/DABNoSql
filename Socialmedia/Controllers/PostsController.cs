using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socialmedia.Models;
using Socialmedia.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Socialmedia.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {

        private readonly PostsService _postsService;

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Post> Create(Post post)
        {
            _postsService.Create(post);
            return CreatedAtRoute("GetPost", new { id = post.Id.ToString() }, post);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Comment(string id, string comment)
        {
            var post = _postsService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            _postsService.CommentPost(id, comment);

            return NoContent(); 

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
