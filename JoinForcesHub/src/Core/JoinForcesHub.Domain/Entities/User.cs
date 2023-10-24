using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities;

public class User :BaseEntity
{
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
    public string PasswordSalt { get; set; }
    public string PasswordHash { get; set; }
    public string PhotoPath { get; set; }
    public string GithubLink { get; set; }
    public string LinkedlnLink { get; set; }
    public string StackOverFlowLink { get; set; }
    public string Location { get; set; }
    public string EducationStatus { get; set; }
    public string JobStatus { get; set; }
    public string IsProfileVisible { get; set; }
    public string CoverPhoto { get; set; }
    public bool IsPremium { get; set; }
}
