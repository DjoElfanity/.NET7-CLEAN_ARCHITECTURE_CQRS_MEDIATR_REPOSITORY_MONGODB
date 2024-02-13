using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Posts.Queries
{
    public class GetPostById : IRequest<Post>
    {
        public string PostId { get; set; } = string.Empty; 
        
    }
}