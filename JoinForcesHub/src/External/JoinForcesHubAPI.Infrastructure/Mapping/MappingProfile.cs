using AutoMapper;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Application.Dtos.Users;

namespace JoinForcesHubAPI.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<UserListDto, User>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
    }
}
