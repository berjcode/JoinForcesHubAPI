using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Teams;

public class TeamMembers : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid TeamId { get; private set; }
    public string RoleName { get; private set; }
    public bool IsCertified { get; private set; }
}
