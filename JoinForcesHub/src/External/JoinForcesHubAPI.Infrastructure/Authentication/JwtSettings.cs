namespace JoinForcesHubAPI.Infrastructure.Authentication;

public class JwtSettings
{
    public int ExpiryMinutes { get; init; }
    public string SecretKey { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public const string SectionName = "JwtSettings";



}
