using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Posts.Command
{
    public class DeletePost : IRequest<Unit>
    {
        public string PostId { get; set; } = string.Empty ; 

    }
}