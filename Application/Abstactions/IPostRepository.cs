using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Abstactions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPosts();
        Task<Post> GetPostById(string postId);

        Task<Post> CreatePost(Post toCreate) ; 

        Task<Post> UpdatePost(string updatedContent, string postId);

        Task DeletePost( string postId);
    }
}