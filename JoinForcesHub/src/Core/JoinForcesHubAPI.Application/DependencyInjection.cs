using Microsoft.Extensions.DependencyInjection;
using JoinForcesHubAPI.Application.Services.Authentication;

namespace JoinForcesHubAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
