using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Socialmedia.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string FullName { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("Posts")]
        public List<Post> Post { get; set; }
         
        [BsonElement("Circles")]
        public List<string> CircleId { get; set; }
        
        [BsonElement("Follows")]
        public List<string> FollowUserId { get; set; }

        [BsonElement("Blocked")]
        public List<string> BlockedUserId { get; set; }
    }
}
