using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Roles;

public class UserRole : BaseEntity
{
    public Guid RoleId { get; private set; }
    public Guid UserId { get; private  set; }
}
