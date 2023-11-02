using FluentValidation;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.Behaviors.FluentValidation.UserRoles;

public class UserRoleUpdateValidator : AbstractValidator<UserRole>
{
    public UserRoleUpdateValidator()
    {
        RuleFor(role => role.Id).NotNull();
        RuleFor(role => role.Id).NotEmpty();
        RuleFor(userRole => userRole.RoleId).NotNull();
        RuleFor(userRole => userRole.RoleId).NotEmpty();
        RuleFor(userRole => userRole.UserId).NotEmpty();
        RuleFor(userRole => userRole.UserId).NotEmpty();
    }
}
