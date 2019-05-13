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
        }

        static async void SeedUser(IMongoCollection<User> user)
        {
            await user.InsertOneAsync(new User {FullName = "Niels"});

        }
    }
}
