namespace JoinForcesHubAPI.Application.Services.Authentication;

public record AuthenticationResult(
Guid Id,
string Firstname,
string SurName,
string Email,
string Token
);

