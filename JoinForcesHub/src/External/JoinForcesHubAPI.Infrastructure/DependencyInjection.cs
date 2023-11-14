using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using JoinForcesHubAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JoinForcesHubAPI.Infrastructure.Authentication;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;
using JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRepositories;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;
using JoinForcesHubAPI.Infrastructure.Persistence.Repositories.RoleRepositories;
using JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRoleRepositories;

namespace JoinForcesHubAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //Jwt
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        //Repository
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IDbContextService, DbContextService>();
        services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IUserRoleQueryRepository, UserRoleQueryRepository>();
        services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();
        //Services
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        //Jwt
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
            });

  
      
        //Context
        services.AddDbContext<JoinForcesHubDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(AppSettingExpression.JoinForcesHubSqlServerConnection)));
        return services;
    }
}
