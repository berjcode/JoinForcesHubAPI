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

    public int Count(Expression<Func<UserRole, bool>> expression)
    {
        return _context.UserRoles.Count(expression);
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
}
