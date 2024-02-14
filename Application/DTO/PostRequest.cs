using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.DTO
{
    public class PostRequest
    {
      
        [BsonElement("Content")]
        public string Content { get; set; } = string.Empty; 
        
    }
}