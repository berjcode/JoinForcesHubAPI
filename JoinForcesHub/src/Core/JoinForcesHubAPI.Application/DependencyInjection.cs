using FluentValidation;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.Extensions.DependencyInjection;
using JoinForcesHubAPI.Application.Services.Roles;
using JoinForcesHubAPI.Application.Services.UserRoles;
using JoinForcesHubAPI.Application.FluentValidation.Roles;
using JoinForcesHubAPI.Application.Services.Authentication;
using JoinForcesHubAPI.Application.FluentValidation.UserRoles;

namespace JoinForcesHubAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        // Validator
        services.AddScoped<IValidator<Role>, RoleCreateValidator>();
        services.AddScoped<IValidator<UserRole>, UserRoleCreateValidator>();

        return services;
    }
}
