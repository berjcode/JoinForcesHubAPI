namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record AuthenticationResponse(
    Guid Id,
    string Firstname,
    string SurName,
    string Email,
    string Token
    );

