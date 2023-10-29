namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record AuthenticationResultDto(
Guid Id,
string Firstname,
string SurName,
string Email,
string Token
);

