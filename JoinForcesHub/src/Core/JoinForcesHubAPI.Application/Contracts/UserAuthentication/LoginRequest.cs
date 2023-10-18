namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record LoginRequest(
    string Email,
    string Password
    );
