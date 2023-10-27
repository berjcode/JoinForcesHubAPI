using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class Project : BaseEntity
{
    public Guid UserId { get;  set; }
    public string ProjectName { get;  set; }
    public string ProjectDescription { get;  set; }
    public string ProjectUrl { get;  set; }
    public string ProjectGithubUrl { get;  set; }
    public DateTime StartDate { get;  set; }
    public DateTime EndDate { get;  set; }
}
