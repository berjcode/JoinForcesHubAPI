using FluentValidation;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Application.Utilities.Messages;

namespace JoinForcesHubAPI.Application.FluentValidation;

public class RoleCreateValidator : AbstractValidator<Role>
{
    public RoleCreateValidator()
    {
        RuleFor(role => role.Description).NotNull();
        RuleFor(role => role.Description).NotEmpty();
        RuleFor(role => role.RoleName).MinimumLength(3);
        RuleFor(role => role.RoleName).MaximumLength(50);
        RuleFor(role => role.RoleName).MaximumLength(50);
        RuleFor(role => role.Description).MinimumLength(1);
        RuleFor(role => role.RoleName).NotNull().WithMessage(ValidationMessages.NotNull);
        RuleFor(role => role.RoleName).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}
