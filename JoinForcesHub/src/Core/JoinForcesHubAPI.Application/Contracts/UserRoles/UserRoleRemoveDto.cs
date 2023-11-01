namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRoleRemoveDto(
     Guid Id,
    bool IsDeleted,
    string UpdatedByUserName
    );
