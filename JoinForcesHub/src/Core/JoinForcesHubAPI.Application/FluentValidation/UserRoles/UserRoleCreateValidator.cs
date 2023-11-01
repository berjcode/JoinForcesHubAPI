using FluentValidation;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.FluentValidation.UserRoles;

public class UserRoleCreateValidator : AbstractValidator<UserRole>
{
    public UserRoleCreateValidator()
    {
        RuleFor(userRole => userRole.RoleId).NotNull();
        RuleFor(userRole => userRole.RoleId).NotEmpty();
        RuleFor(userRole => userRole.UserId).NotEmpty();
        RuleFor(userRole => userRole.UserId).NotEmpty();
    }
}
