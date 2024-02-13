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

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();


var app = builder.Build();



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
