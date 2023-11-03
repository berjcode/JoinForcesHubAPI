using AutoMapper;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Application.Contracts.Users;
using JoinForcesHubAPI.Application.Contracts.Roles;
using JoinForcesHubAPI.Application.Contracts.UserRoles;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubAPI.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<UserListDto, User>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

        //Auth
        CreateMap<RegisterRequest, User>().ReverseMap();

        // Role
        CreateMap<RoleDto, Role>().ReverseMap();
        CreateMap<RoleListDto, Role>().ReverseMap();
        CreateMap<RoleCreateDto, Role>().ReverseMap();
        CreateMap<RoleRemoveDto, Role>().ReverseMap();
        CreateMap<RoleUpdateDto, Role>().ReverseMap();

        // UserRole
        CreateMap<UserRoleDto, UserRole>().ReverseMap();
        CreateMap<UserRoleListDto, UserRole>().ReverseMap();
        CreateMap<UserRoleUpdateDto, UserRole>().ReverseMap();
        CreateMap<UserRoleCreateDto, UserRole>().ReverseMap();
        CreateMap<UserRoleRemoveDto, UserRole>().ReverseMap();
        CreateMap<UserRolesByUserIdListDto, UserRole>().ReverseMap();
    }
}
