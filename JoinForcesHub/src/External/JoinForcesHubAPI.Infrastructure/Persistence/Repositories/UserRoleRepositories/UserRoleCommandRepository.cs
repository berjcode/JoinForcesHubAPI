using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRoleRepositories;

public class UserRoleCommandRepository : IUserRoleCommandRepository
{
    private readonly JoinForcesHubDbContext _context;

    public UserRoleCommandRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        
        if (await _context.UserRoles.AddAsync(userRole, cancellationToken) !=null)
            return true;

        return false;
    }

    public async Task AddRangeAsync(IEnumerable<UserRole> userRoles, CancellationToken cancellationToken)
    {
        await _context.UserRoles.AddRangeAsync(userRoles, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.AnyAsync(predicate);
    }

    public void Remove(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);

        _context.SaveChanges();
    }

    public void RemoveRange(IEnumerable<UserRole> userRoles)
    {
        _context.UserRoles.RemoveRange(userRoles);

        _context.SaveChanges();
    }

    public void Update(UserRole userRole)
    {
        _context.UserRoles.Update(userRole);
        _context.SaveChanges();
    }

    public void UpdateRange(IEnumerable<UserRole> userRoles)
    {
        _context.UserRoles.UpdateRange(userRoles);
        _context.SaveChanges();
    }
}
