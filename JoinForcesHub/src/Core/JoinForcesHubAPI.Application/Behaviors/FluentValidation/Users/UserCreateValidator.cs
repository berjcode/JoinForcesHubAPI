using FluentValidation;
using JoinForcesHub.Domain.Entities.User;
using System.Text.RegularExpressions;

namespace JoinForcesHubAPI.Application.Behaviors.FluentValidation.Users;

public class UserCreateValidator : AbstractValidator<User>
{
    public UserCreateValidator()
    {
        RuleFor(user => user.About).NotNull();
        RuleFor(user => user.Email).NotNull();
        RuleFor(user => user.About).NotEmpty();
        RuleFor(user => user.Email).NotEmpty();
        RuleFor(user => user.SurName).NotNull();
        RuleFor(user => user.UserName).NotNull();
        RuleFor(user => user.SurName).NotEmpty();
        RuleFor(user => user.PasswordHash).NotEmpty();
        RuleFor(user => user.FirstName).NotNull();
        RuleFor(user => user.UserName).NotEmpty();
        RuleFor(user => user.FirstName).NotEmpty();
        RuleFor(user => user.Location).NotNull();
        RuleFor(user => user.Location).NotEmpty();
        RuleFor(user => user.JobStatus).NotNull();
        RuleFor(user => user.PhotoPath).NotNull();
        RuleFor(user => user.PhotoPath).NotEmpty();
        RuleFor(user => user.JobStatus).NotEmpty();
        RuleFor(user => user.About).MinimumLength(2);
        RuleFor(user => user.Email).MinimumLength(2);
        RuleFor(user => user.Email).MinimumLength(2);
        RuleFor(user => user.Email).MaximumLength(50);
        RuleFor(user => user.Email).MaximumLength(50);
        RuleFor(user => user.SurName).MinimumLength(2);
        RuleFor(user => user.About).MaximumLength(500);
        RuleFor(user => user.EducationStatus).NotNull();
        RuleFor(user => user.SurName).MaximumLength(50);
        RuleFor(user => user.Location).MinimumLength(2);
        RuleFor(user => user.FirstName).MinimumLength(2);
        RuleFor(user => user.FirstName).MaximumLength(50);
        RuleFor(user => user.EducationStatus).NotEmpty();
        RuleFor(user => user.PhotoPath).MinimumLength(2);
        RuleFor(user => user.Location).MaximumLength(100);
        RuleFor(user => user.EducationStatus).MinimumLength(2);
        RuleFor(user => user.EducationStatus).MaximumLength(50);
        RuleFor(user => user.PasswordHash).NotNull().Must(BeValidPassword).WithMessage("Geçerli bir şifre sağlanmalıdır.");

    }
    private bool BeValidPassword(string password)
    {
        if (password.Length < 3 && password.Length > 30)
            return false;
        if (!Regex.IsMatch(password, "[A-Z]"))
            return false;

        if (!Regex.IsMatch(password, "[a-z]"))
            return false;

        if (!password.Any(char.IsSymbol))
            return false;

        if (!password.Any(char.IsDigit))
            return false;

        return true;
    }
}
