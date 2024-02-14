using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.DTO
{
    public class PostResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  = string.Empty ;

        [BsonElement("Content")]
        public string Content { get; set; } = string.Empty; 

    }
}