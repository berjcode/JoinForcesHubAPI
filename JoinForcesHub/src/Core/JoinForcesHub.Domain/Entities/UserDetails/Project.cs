using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class Project : BaseEntity
{
    public Guid UserId { get; private set; }
    public string ProjectName { get; private set; }
    public string ProjectDescription { get; private set; }
    public string ProjectUrl { get; private set; }
    public string ProjectGithubUrl { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
}
