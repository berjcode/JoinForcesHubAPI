using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRoleRepositories;

public class UserRoleQueryRepository : IUserRoleQueryRepository
{
    //Compiled Queries
    private static readonly Func<JoinForcesHubDbContext, bool, Task<UserRole>> GetFirstCompiled =
       EF.CompileAsyncQuery((JoinForcesHubDbContext context, bool isTracking) =>
       isTracking == true ? context.UserRoles.FirstOrDefault()
       : context.UserRoles.AsNoTracking().FirstOrDefault());



    private readonly JoinForcesHubDbContext _context;

    public UserRoleQueryRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync(Expression<Func<UserRole, bool>> expression)
    {
        return await _context.UserRoles.CountAsync(expression);
    }

    public IQueryable<UserRole> GetAll(bool isTracking = true)
    {
        var result = _context.UserRoles.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }

    public async Task<UserRole> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public IQueryable<UserRole> GetWhere(Expression<Func<UserRole, bool>> expression, bool isTracking = true)
    {
        var result = _context.UserRoles.Where(expression);
        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }


    public Task<UserRole> GetFirstExpression(Expression<Func<UserRole, bool>> expression, bool isTracking = true)
    {
        if (isTracking)
        {
            return _context.UserRoles.FirstOrDefaultAsync(expression);
        }
        else
        {
            return _context.UserRoles.AsNoTracking().FirstOrDefaultAsync(expression);
        }
    }

    public async Task<bool> AnyAsync(Expression<Func<UserRole, bool>> predicate)
    {
        return await _context.UserRoles.AnyAsync(predicate);
    }


    public async Task<IList<UserRole>> GetAllExpressionAsync(Expression<Func<UserRole, bool>> predicate = null, params Expression<Func<UserRole, object>>[] includeProperties)
    {
        IQueryable<UserRole> query = _context.UserRoles;
        if (predicate != null)
            query = query.Where(predicate);
       
        if (includeProperties.Any())
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.ToListAsync();
    }
}
