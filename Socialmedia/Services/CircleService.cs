﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Socialmedia.Models;

namespace Socialmedia.Services
{
    public class CircleService
    {

        private readonly IMongoCollection<Circle> _circles;

        public CircleService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SocialMediaDb"));
            var database = client.GetDatabase("SocialMediaDb");
            _circles = database.GetCollection<Circle>("Circles");
        }

        public List<Circle> Get()
        {
            return _circles.Find(circle => true).ToList();
        }

        public Circle Get(string id)
        {
            return _circles.Find<Circle>(circle => circle.Id == id).FirstOrDefault();
        }

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(Circle circle)
        {
            _circles.ReplaceOne(circleOld => circleOld.Id == circle.Id, circle); 
        }

        public void AddUser(Circle circle, string userId)
        {
            circle.UserId.Add(userId);
            Update(circle);
        }
    }
}
