namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record PasswordDto(
    string Salt,
    string PasswordHash);
