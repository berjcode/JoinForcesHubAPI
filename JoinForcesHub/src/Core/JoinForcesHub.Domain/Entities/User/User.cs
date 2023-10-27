using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.User;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = null!;
    public string SurName { get; private set; } = null!;
    public string UserName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string About { get; private set; }
    public string Password { get; private set; }
    public string PhotoPath { get; private set; }
    public string GithubLink { get; private set; }
    public string LinkedlnLink { get; private set; }
    public string StackOverFlowLink { get; private set; }
    public string Location { get; private set; }
    public string EducationStatus { get; private set; }
    public string JobStatus { get; private set; }
    public bool IsProfileVisible { get; private set; } = false;
    public string CoverPhoto { get; private set; }
    public bool IsPremium { get; private set; } = false;
}
