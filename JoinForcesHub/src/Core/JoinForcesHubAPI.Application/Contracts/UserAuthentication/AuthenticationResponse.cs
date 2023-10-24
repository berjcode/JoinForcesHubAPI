namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record AuthenticationResponse(
    Guid Id,
    string Firstname,
    string LastName,
    string Email,
    string Token
    );
