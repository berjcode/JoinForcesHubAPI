namespace JoinForcesHubAPI.Application.Services.Authentication;

public record AuthenticationResult(
Guid Id,
string Firstname,
string LastName,
string Email,
string Token
);

