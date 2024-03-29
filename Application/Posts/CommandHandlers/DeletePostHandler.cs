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
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postsRepo;
        public DeletePostHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }
        public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
        {
                await _postsRepo.DeletePost(request.PostId);
                return Unit.Value; 

        }
    }
}