using FluentValidation;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.Extensions.DependencyInjection;
using JoinForcesHubAPI.Application.Services.Roles;
using JoinForcesHubAPI.Application.FluentValidation;
using JoinForcesHubAPI.Application.Services.Authentication;

namespace JoinForcesHubAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        // Validator
        services.AddScoped<IValidator<Role>, RoleCreateValidator>();

        return services;
    }
}
