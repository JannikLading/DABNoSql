using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Socialmedia.Models;

namespace Socialmedia.Services
{
    public class PostsService
    {

        private readonly IMongoCollection<Post> _posts;

        public PostsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SocialMediaDb"));
            var database = client.GetDatabase("SocialMediaDb");
            _posts = database.GetCollection<Post>("Posts");
        }

        public List<Post> Get()
        {
            return _posts.Find(post => true).ToList();
        }

        public Post Get(string id)
        {
            return _posts.Find<Post>(post => post.Id == id).FirstOrDefault();
        }

        public Post Create(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public void Update(string id, Post postIn)
        {
            _posts.ReplaceOne(post => post.Id == id, postIn);
        }

        public void Remove(Post postIn)
        {
            _posts.DeleteOne(post => post.Id == postIn.Id);
        }

        public void Remove(string id)
        {
            _posts.DeleteOne(post => post.Id == id);
        }
    }
}
