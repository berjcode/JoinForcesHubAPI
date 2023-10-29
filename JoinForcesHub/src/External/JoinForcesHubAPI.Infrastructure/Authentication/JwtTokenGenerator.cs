using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;

namespace JoinForcesHubAPI.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string surName, List<string> roles)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
           new Claim(JwtRegisteredClaimNames.GivenName,firstName),
           new Claim(JwtRegisteredClaimNames.FamilyName,surName),
           new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           new Claim(ClaimTypes.Role,string.Join(",", roles))
       };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
