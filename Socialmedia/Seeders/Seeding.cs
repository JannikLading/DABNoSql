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
            SeedPost(_posts);
        }

        static async void SeedUser(IMongoCollection<User> user)
        {
            var users = new List<User>
            {
                new User
                {
                    FullName = "Niels",
                    Id = "000000000000000000000000",
                    PostId = new List<string> {"100000000000000000000000"},
                    CircleId=new List<string>{},
                    FollowUserId = new List<string>{},
                    BlockedUserId = new List<string>{}
                },
                new User
                {
                    FullName = "Janz",
                    Id = "000000000000000000000001",
                    PostId = new List<string>{},
                    CircleId=new List<string>{},
                    FollowUserId = new List<string>{},
                    BlockedUserId = new List<string>{}
                }
            };
            await user.InsertManyAsync(users);
        }

        static async void SeedPost(IMongoCollection<Post> post)
        {
            await post.InsertOneAsync(new Post
            {
                Id = "100000000000000000000000",
                ContentText = "Dette er en post",
                UserId = "000000000000000000000000"
            });
        }
    }
}
