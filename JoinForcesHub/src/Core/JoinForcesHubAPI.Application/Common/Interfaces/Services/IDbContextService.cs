using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore.Storage;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Services;

public interface IDbContextService
{
    DbSet<User> Users { get;  }
    DbSet<Role> Roles { get;  }
    DbSet<UserRole> UserRoles { get;  }
   
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
