using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstactions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandler
{
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _postsRepo; 
        public GetPostByIdHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }
        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
                return await _postsRepo.GetPostById(request.PostId);
        }
    }
}