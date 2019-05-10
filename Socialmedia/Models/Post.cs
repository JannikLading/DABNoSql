using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Socialmedia.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
            
        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("User")]
        public string UserId { get; set; }

        [BsonElement("Circle")]
        public string CircleId { get; set; }

        [BsonElement("ContentText")]
        public string ContentText { get; set; }

        [BsonElement("ContentPicture")]
        public string ContentPicture { get; set; }

        [BsonElement("Comments")]
        public List<String> Comments { get; set; }
            
    }
}
