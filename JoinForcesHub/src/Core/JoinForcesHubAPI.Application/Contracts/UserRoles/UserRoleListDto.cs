﻿namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRoleListDto(
    Guid RoleId,
    string RolesRoleName,
    Guid UserId,
    string UsersUserName
    );
