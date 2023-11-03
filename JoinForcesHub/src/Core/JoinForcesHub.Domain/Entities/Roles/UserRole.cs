using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Roles;

public class UserRole : BaseEntity
{
    public Guid RoleId { get;  set; }
    public Roles.Role Roles { get;  set; }
    public Guid UserId { get;  set; }
    public User.User Users { get;  set; }


}
