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
    public class CirclesController : ControllerBase
    {
        private readonly CircleService _circleService;

        public CirclesController(CircleService circleService)
        {
            _circleService = circleService;
        }

        [HttpGet]
        public ActionResult<List<Circle>> Get()
        {
            return _circleService.Get();
        }
        
        [HttpGet("{id}", Name = "GetCircle")]
        public ActionResult<Circle> Get(string id)
        {
            var circle = _circleService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<Circle> Create(Circle circle)
        {
            _circleService.Create(circle);
            return CreatedAtRoute("GetCircle", new { id = circle.Id.ToString() }, circle);
        }

        [HttpPatch("{circleId}/{userId}")]
        public ActionResult<Circle> AddUserToCircle(string circleId, string userId)
        {
            Circle circle = _circleService.Get(circleId); 
            _circleService.AddUser(circle, userId);

            return circle; 
        }
    }
}