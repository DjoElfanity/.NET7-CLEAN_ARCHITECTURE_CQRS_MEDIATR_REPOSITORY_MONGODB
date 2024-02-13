using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Posts.Command;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Abstractions;

namespace MinimalApi.EndPointsDefinitions
{
    public class PostEndPointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/api/posts/{id}" , async (IMediator mediator , string id)=>
{
 var getPost = new GetPostById {PostId = id} ; 
 var post = await mediator.Send(getPost);

 return Results.Ok(post);
}
).WithName("GetPostById");

app.MapPost("/api/posts" ,async (IMediator mediator , [FromBody]Post post)=>
{
    var createPost = new CreatePost {PostContent  = post.Content};
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById", new { createdPost.Id} , createdPost);
}
);

app.MapGet("/api/posts" , async (IMediator mediator) =>
{
    var getAllPost = new GetAllPosts();
    var posts = await mediator.Send(getAllPost);
    return Results.Ok(posts);  
});


app.MapPut("/api/posts/{id}" , async (IMediator mediator, Post post , string id)=>
{
    var updatePost  =new UpdatePost { PostId  = id , PostContent = post.Content};
    var updatedPost =  await mediator.Send(updatePost);
    return Results.Ok(updatedPost);
}
);

app.MapDelete("/api/posts/{id}" , async (IMediator mediator , string id)=>
{
    var deletePost = new DeletePost{PostId = id}; 
    var deletedPost = await mediator.Send(deletePost);
    return Results.Ok("Post Deleted successuly");
    }

);
        }
    }
}