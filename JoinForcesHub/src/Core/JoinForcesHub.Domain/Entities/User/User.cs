using JoinForcesHub.Domain.Abstract;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHub.Domain.Entities.User;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public string UserJobTitle { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string About { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string PhotoPath { get; set; }
    public string GithubLink { get; set; }
    public string LinkedlnLink { get; set; }
    public string StackOverFlowLink { get; set; }
    public string Location { get; set; }
    public string EducationStatus { get; set; }
    public string JobStatus { get; set; }
    public bool IsProfileVisible { get; set; } = false;
    public string CoverPhoto { get; set; }
    public bool IsPremium { get; set; } = false;
    public string RefreshToken { get; set; } = null;
    public DateTime? RefreshTokenEndData { get; set; }
    public bool NumberConfirmed { get; set; } = false;
    public bool TwoFactorEnabled { get; set; } = false;
    public ICollection<UserRole> UserRoles { get; set; }
}
