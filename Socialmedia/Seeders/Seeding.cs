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
        private readonly IMongoCollection<Circle> _circles;


        public Seeding(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SocialMediaDb"));
            var database = client.GetDatabase("SocialMediaDb");
            _users = database.GetCollection<User>("Users");
            _posts = database.GetCollection<Post>("Posts");
            _circles = database.GetCollection<Circle>("Circles");

            SeedUser(_users);
            SeedPost(_posts);
            SeedCircle(_circles);
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
                    CircleId=new List<string>{"010000000000000000000000"},
                    FollowUserId = new List<string>{"000000000000000000000010"},
                    BlockedUserId = new List<string>{ "000000000000000000000011" }
                },
                new User
                {
                    FullName = "Janz",
                    Id = "000000000000000000000001",
                    PostId = new List<string>{},
                    CircleId=new List<string>{"010000000000000000000000"},
                    FollowUserId = new List<string>{},
                    BlockedUserId = new List<string>{}
                }, 
                new User
                {
                    FullName = "NoobSlayer69",
                    Id="000000000000000000000010",
                    PostId = new List<string> {"100000000000000000000010"},
                    CircleId=new List<string>{},
                    FollowUserId = new List<string>{},
                    BlockedUserId = new List<string>{}

                },
                new User
                {
                    FullName = "TheLegend27",
                    Id = "000000000000000000000011",
                    PostId = new List<string> {"100000000000000000000011"},
                    CircleId=new List<string>{},
                    FollowUserId = new List<string>{},
                    BlockedUserId = new List<string>{}

                }
            };
            await user.InsertManyAsync(users);
        }

        static async void SeedPost(IMongoCollection<Post> post)
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Id = "100000000000000000000000",
                    ContentText = "Dette er en post1",
                    UserId = "000000000000000000000000",
                    CircleId = null

                },
                new Post
                {
                    Id = "100000000000000000000001",
                    ContentText = "Dette er en post2",
                    CircleId = "010000000000000000000000",
                    UserId = "000000000000000000000000"
                },
                new Post
                {
                    Id="100000000000000000000010",
                    ContentText = "Dette er en post3",
                    UserId = "000000000000000000000010"
                },
                new Post
                {
                    Id="100000000000000000000011",
                    ContentText = "Dette er en post4",
                    UserId = "0000000000000000000011",
                },
                new Post
                {
                    Id = "100000000000000000000100",
                    ContentText = "Dette er en post5",
                    UserId = "000000000000000000000001",
                    CircleId = "010000000000000000000000"
                }
            };
            await post.InsertManyAsync(posts);
        }

        static async void SeedCircle(IMongoCollection<Circle> circle)
        {
            var circles = new Circle

            {
                Id = "010000000000000000000000",
                PostId = new List<string> {"100000000000000000000001", "100000000000000000000100" },
                UserId = new List<string> {"000000000000000000000000", "000000000000000000000001" }
            };
            await circle.InsertOneAsync(circles);   
        }
    }
}
