using Domain.Models;
using MongoDB.Driver;
using DataAccess.Configurations;
using Microsoft.Extensions.Options;

namespace DataAccess
{
    public class SocialDbContext
    {
        private readonly IMongoCollection<Post> _postCollection;

        public SocialDbContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _postCollection = mongoDb.GetCollection<Post>(mongoDbSettings.Value.CollectionName);
        }

        public IMongoCollection<Post> Posts => _postCollection;
    }
}
