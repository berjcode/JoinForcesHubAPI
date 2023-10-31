using Microsoft.Extensions.DependencyInjection;
using JoinForcesHubAPI.Application.Services.Authentication;
using JoinForcesHubAPI.Application.Services.Roles;

namespace JoinForcesHubAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
