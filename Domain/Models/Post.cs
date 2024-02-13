using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  = string.Empty ;

        [BsonElement("Content")]
        public string Content { get; set; } = string.Empty; 
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
        
}