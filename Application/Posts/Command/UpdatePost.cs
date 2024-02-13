using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Domain.Models;
using MediatR;

namespace Application.Posts.Command
{
    public class UpdatePost : IRequest<Post>
    {
        public string PostId {get ; set;}  = string.Empty;
        public string? PostContent {get ; set;}

    }
}