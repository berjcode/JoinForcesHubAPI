using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
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

    public string GenerateRefreshToken()
    {
        byte[] number = new byte[32];

        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(number);
        }

        return Convert.ToBase64String(number);
    }

    public TokenDto GenerateToken(Guid userId, string firstName, string surName, List<string> roles)
    {
        TokenDto token = new TokenDto();

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var claims = GenerateClaims(userId, firstName, surName, roles);


        token.AccessTokenExpiration = _dateTimeProvider.NowTime.AddMinutes(_jwtSettings.ExpiryMinutes);

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.NowTime.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        token.AccessToken = tokenHandler.WriteToken(securityToken);
        token.RefreshToken = GenerateRefreshToken();
        token.RefreshTokenExpiration = _dateTimeProvider.NowTime.AddMinutes(_jwtSettings.RefreshTokenExpiryMinutes);

        return token;
    }

    private Claim[] GenerateClaims(Guid userId, string firstName, string surName, List<string> roles)
    {
        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
           new Claim(JwtRegisteredClaimNames.GivenName,firstName),
           new Claim(JwtRegisteredClaimNames.FamilyName,surName),
           new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           new Claim(ClaimTypes.Role,string.Join(",", roles))
       };

        return claims;
    }
}
