using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

public interface IRoleCommandRepository
{
    void Update(Role role);
    void Remove(Role role);
    void UpdateRange(IEnumerable<Role> role);
    void RemoveRange(IEnumerable<Role> role);
    Task<bool> AddAsync(Role role, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<Role> role, CancellationToken cancellationToken);
}
