using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Socialmedia.Models;

namespace Socialmedia.Seeders
{
    public class Seeding
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Post> _posts;
        private readonly IMongoCollection<Circle> _circle;


        public Seeding(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SocialMediaDb"));
            var database = client.GetDatabase("SocialMediaDb");
            _users = database.GetCollection<User>("Users");
            _posts = database.GetCollection<Post>("Posts");
            _circle = database.GetCollection<Circle>("Circle");

            SeedUser(_users);
            SeedPost(_posts, _users);
        }

        static async void SeedUser(IMongoCollection<User> user)
        {
            await user.InsertOneAsync(new User
            {
                FullName = "Niels", Id="000000000000000000000000",
                PostId = new List<string>{"100000000000000000000000"}
            });

        }

        static async void SeedPost(IMongoCollection<Post> post, IMongoCollection<User> User)
        {
            await post.InsertOneAsync(new Post
            {
                ContentText = "Dette er en post",
                UserId = "000000000000000000000000"
            });
        }
    }
}
