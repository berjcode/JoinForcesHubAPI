namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
    );
