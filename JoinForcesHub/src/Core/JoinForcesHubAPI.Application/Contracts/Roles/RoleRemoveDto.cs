namespace JoinForcesHubAPI.Application.Contracts.Roles;

public record RoleRemoveDto(
    Guid Id,
    bool IsDeleted,
    string UpdatedByUserName
    );
