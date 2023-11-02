using FluentValidation;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.Behaviors.FluentValidation.Roles;

public class RoleUpdateValidator : AbstractValidator<Role>
{
    public RoleUpdateValidator()
    {
        RuleFor(role => role.Id).NotNull();
        RuleFor(role => role.Id).NotEmpty();
        RuleFor(role => role.RoleName).NotNull();
        RuleFor(role => role.RoleName).NotEmpty();
        RuleFor(role => role.Description).NotNull();
        RuleFor(role => role.Description).NotEmpty();
        RuleFor(role => role.RoleName).MinimumLength(3);
        RuleFor(role => role.RoleName).MaximumLength(50);
        RuleFor(role => role.RoleName).MaximumLength(50);
        RuleFor(role => role.Description).MinimumLength(1);

    }
}
