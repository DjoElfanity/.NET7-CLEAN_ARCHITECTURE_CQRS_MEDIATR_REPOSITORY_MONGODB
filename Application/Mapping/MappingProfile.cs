using Application.DTO;
using AutoMapper;
using Domain.Models;

namespace dotnet_test.Mapping
{
    public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, PostResponse>();
        CreateMap<PostRequest, Post>();
    }
}
}