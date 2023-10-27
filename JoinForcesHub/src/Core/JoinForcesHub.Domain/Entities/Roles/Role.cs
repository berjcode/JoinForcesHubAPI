using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Roles;

public class Role : BaseEntity
{
    public string RoleName { get;  set; }
    public string Description { get;  set; }

    //
    public ICollection<UserRole> UserRoles { get;  set; }
}
