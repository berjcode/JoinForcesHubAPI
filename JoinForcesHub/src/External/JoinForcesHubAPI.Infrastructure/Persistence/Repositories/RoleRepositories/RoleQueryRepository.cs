using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.RoleRepositories;

public class RoleQueryRepository : IRoleQueryRepository
{
    //Compiled Queries 
    private static readonly Func<JoinForcesHubDbContext, bool, Task<Role>> GetFirstCompiled =
   EF.CompileAsyncQuery((JoinForcesHubDbContext context, bool isTracking) =>
   isTracking == true ? context.Roles.FirstOrDefault()
   : context.Roles.AsNoTracking().FirstOrDefault());

    private readonly JoinForcesHubDbContext _context;
    public RoleQueryRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync(Expression<Func<Role, bool>> expression)
    {
        return await _context.Roles.CountAsync(expression);
    }

    public IQueryable<Role> GetAll(bool isTracking = true)
    {
        var result = _context.Roles.AsQueryable();

        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }

    public async Task<Role> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public Task<Role> GetFirstExpression(Expression<Func<Role, bool>> expression, bool isTracking = true)
    {
        if (isTracking)
        {
            return _context.Roles.FirstOrDefaultAsync(expression);
        }
        else
        {
            return _context.Roles.AsNoTracking().FirstOrDefaultAsync(expression);
        }
    }

    public IQueryable<Role> GetWhere(Expression<Func<Role, bool>> expression, bool isTracking = true)
    {
        var result = _context.Roles.Where(expression);

        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }
}
