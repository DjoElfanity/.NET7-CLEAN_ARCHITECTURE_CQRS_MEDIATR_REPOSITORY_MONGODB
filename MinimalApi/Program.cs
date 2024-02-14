using Application.Abstactions;
using Infrastructure;
using Infrastructure.Configurations;
using Infrastructure.Repositories;
using MongoDB.Driver;
using MediatR;
using Application.Posts.Command;
using Application.Posts.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using dotnet_test.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// GLOBAL EXCEPTION HANDLED IN A MIDDLEWARE
// app.Use(async (ctx , next) =>
// {
//         try 
//             {
//                 await next();
//             }
//         catch(Exception)
//             {
//                 ctx.Response.StatusCode = 500; 
//                 await ctx.Response.WriteAsync("An error occured");
//             }
// }
// );


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpointsDefinition();

app.UseAuthorization();

app.MapControllers();

app.Run();
