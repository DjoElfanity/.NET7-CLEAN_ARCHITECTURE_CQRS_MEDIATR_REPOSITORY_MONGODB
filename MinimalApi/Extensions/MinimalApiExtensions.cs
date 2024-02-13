using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstactions;
using Application.Posts.Command;
using DataAccess;
using DataAccess.Configurations;
using DataAccess.Repositories;
using MediatR;
using MinimalApi.Abstractions;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPostRepository , PostRepository>() ;
            builder.Services.Configure<MongoDbSettings>(
                builder.Configuration.GetSection("MongoDatabase"));



            builder.Services.AddSingleton<SocialDbContext>();
            builder.Services.AddMediatR(typeof(CreatePost));



        }

        public static void RegisterEndpointsDefinition( this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
        .GetTypes()
        .Where( t => t.IsAssignableTo(typeof(IEndpointDefinition)) 
        && !t.IsAbstract && !t.IsInterface
        )
        .Select(Activator.CreateInstance)
        .Cast<IEndpointDefinition>() ; 

        foreach(var endpointDef in endpointDefinitions)
        {
            endpointDef.RegisterEndpoints(app);
        }
            
    }
        
    }


    
}