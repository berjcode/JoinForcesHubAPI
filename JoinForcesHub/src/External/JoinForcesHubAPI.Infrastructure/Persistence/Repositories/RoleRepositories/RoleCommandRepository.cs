using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.RoleRepositories;

public class RoleCommandRepository : IRoleCommandRepository 
{
    private readonly JoinForcesHubDbContext _context;

    public RoleCommandRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Role role, CancellationToken cancellationToken)
    {
        await _context.Roles.AddAsync(role, cancellationToken);
        if (await _context.Roles.AddAsync(role, cancellationToken) !=null)
            return true;

        return false;
    }

    public async Task AddRangeAsync(IEnumerable<Role> role, CancellationToken cancellationToken)
    {
        await _context.Roles.AddRangeAsync(role, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Remove(Role role)
    {
        _context.Roles.Remove(role);

        _context.SaveChanges();
    }


    public void RemoveRange(IEnumerable<Role> role)
    {
        _context.Roles.RemoveRange(role);

        _context.SaveChanges();
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }

    public void UpdateRange(IEnumerable<Role> role)
    {
        _context.Roles.UpdateRange(role);
        _context.SaveChanges();
    }
}
