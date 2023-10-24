using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JoinForcesHubAPI.Infrastructure.Services;
using JoinForcesHubAPI.Infrastructure.Authentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance;
using JoinForcesHubAPI.Infrastructure.Persistence.Repositories;

namespace JoinForcesHubAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        //Repository
        services.AddScoped<IUserRepository, UserRepository>();
        //Services
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


        return services;
    }
}
