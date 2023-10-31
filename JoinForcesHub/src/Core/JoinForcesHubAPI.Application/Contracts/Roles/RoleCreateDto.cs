namespace JoinForcesHubAPI.Application.Contracts.Roles;

public record RoleCreateDto(
    string RoleName,
    string Description,
    string CreatedByUserName
    );
