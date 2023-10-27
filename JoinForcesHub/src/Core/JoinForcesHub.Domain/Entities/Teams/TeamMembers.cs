using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Teams;

public class TeamMembers : BaseEntity
{
    public Guid UserId { get;  set; }
    public Guid TeamId { get;  set; }
    public string RoleName { get;  set; }
    public bool IsCertified { get;  set; }
}
