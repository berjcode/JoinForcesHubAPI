using System.Linq.Expressions;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHub.Domain.Entities.User;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

public interface IUserRoleCommandRepository
{
    void Update(UserRole userRole);
    void Remove(UserRole userRole);
    void UpdateRange(IEnumerable<UserRole> userRoles);
    void RemoveRange(IEnumerable<UserRole> userRoles);
    Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
    Task<bool> AddAsync(UserRole userRole, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<UserRole> userRoles, CancellationToken cancellationToken);
}
