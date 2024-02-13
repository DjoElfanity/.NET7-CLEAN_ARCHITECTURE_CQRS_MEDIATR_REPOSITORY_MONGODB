using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Domain.Models;
using MediatR;

namespace Application.Posts.Queries
{
    public class GetAllPosts : IRequest<ICollection<Post>>
    {
        
    }
}