using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Models;

namespace MinimalApi.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<PostRequest>(1);
            if(string.IsNullOrEmpty(post?.Content))
                return await Task.FromResult(Results.BadRequest("Post non valid"));
                return await next(context);
            
        }
    }
}