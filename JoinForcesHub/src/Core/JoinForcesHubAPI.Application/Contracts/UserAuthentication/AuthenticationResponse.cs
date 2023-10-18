namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record AuthenticationResponse(
    string Firstname,
    string LastName,
    string Email,
    string Token
    );
