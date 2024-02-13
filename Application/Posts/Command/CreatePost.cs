using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Domain.Models;
using MediatR;

namespace Application.Posts.Command
{
    public class CreatePost : IRequest<Post>
    {
        public string ?PostContent { get ; set; } 
        
    }
}