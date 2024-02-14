using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Posts.Command;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Abstractions;
using MinimalApi.Filters;

namespace MinimalApi.EndPointsDefinitions
{
    public class PostEndPointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
           var posts =  app.MapGroup("/api/posts");
            posts.MapGet("/{id}" , async (IMediator mediator , string id)=>
{
 var getPost = new GetPostById {PostId = id} ; 
 var post = await mediator.Send(getPost);

 return Results.Ok(post);
}
).WithName("GetPostById");

posts.MapPost("/" ,async (IMediator mediator , [FromBody]PostRequest post)=>
{
    var createPost = new CreatePost {PostContent  = post.Content};
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById", new { createdPost.Id} , createdPost);
}
).AddEndpointFilter<PostValidationFilter>();

posts.MapGet("/" , async (IMediator mediator) =>
{
    var getAllPost = new GetAllPosts();
    var posts = await mediator.Send(getAllPost);
    return Results.Ok(posts);  
});


posts.MapPut("/{id}" , async (IMediator mediator, PostRequest post , string id)=>
{
    var updatePost  =new UpdatePost { PostId  = id , PostContent = post.Content};
    var updatedPost =  await mediator.Send(updatePost);
    return Results.Ok(updatedPost);
}
).AddEndpointFilter<PostValidationFilter>();

posts.MapDelete("/{id}" , async (IMediator mediator , string id)=>
{
    var deletePost = new DeletePost{PostId = id}; 
    var deletedPost = await mediator.Send(deletePost);
    return Results.Ok("Post Deleted successuly");
    }

);
        }
    }
}