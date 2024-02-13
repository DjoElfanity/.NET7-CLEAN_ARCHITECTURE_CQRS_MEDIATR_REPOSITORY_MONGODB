using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Abstactions;
using Domain.Models;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _postCollection;

        public PostRepository(SocialDbContext dbContext)
        {
            _postCollection = dbContext.Posts;
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            await _postCollection.InsertOneAsync(toCreate);
            return toCreate;
        }

        public async Task DeletePost(string postId)
        {
            await _postCollection.DeleteOneAsync(p => p.Id == postId);
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _postCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Post> GetPostById(string postId)
        {
            return await _postCollection.Find(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task<Post> UpdatePost(string updatedContent, string postId)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.Id, postId);
            var update = Builders<Post>.Update.Set(p => p.Content, updatedContent).Set(p => p.LastModified, DateTime.Now);
            await _postCollection.UpdateOneAsync(filter, update);
            return await GetPostById(postId);
        }
    }
}
