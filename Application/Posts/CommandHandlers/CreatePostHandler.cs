using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstactions;
using Application.Posts.Command;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postsRepo; 
        public CreatePostHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }
        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post 
            {
                Content = request.PostContent
            
            };

            return await _postsRepo.CreatePost(newPost); 
        }
    }
}