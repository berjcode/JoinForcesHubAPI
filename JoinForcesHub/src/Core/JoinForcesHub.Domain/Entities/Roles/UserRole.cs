﻿using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Roles;

public class UserRole : BaseEntity
{
    public Guid RoleId { get;  set; }
    public Role Role { get;  set; }
    public Guid UserId { get;  set; }
    public User.User Users { get;  set; }
}
