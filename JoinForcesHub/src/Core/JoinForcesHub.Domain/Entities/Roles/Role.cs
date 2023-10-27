using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Roles;

public class Role : BaseEntity
{
    public string RoleName { get; private set; }
    public string Description { get; private set; }
}
