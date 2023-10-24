namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record RegisterRequest(
    string FirstName,
    string SurName,
    string Email,
    string Password
    );
