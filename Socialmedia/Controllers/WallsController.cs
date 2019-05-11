using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialmedia.Models;

namespace Socialmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WallsController : ControllerBase
    {
        private readonly UsersController _usersController;

        public WallsController(UsersController usersController)
        {
            _usersController = usersController;
        }

        [HttpGet("user_id, guest_id")]
        public ActionResult<Post> Get(string user_id, string guest_id)
        {
            
        }
    }
}