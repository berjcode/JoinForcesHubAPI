using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRepositories;

public class UserQueryRepository : IUserQueryRepository
{
    //Compiled Queries
    private static readonly Func<JoinForcesHubDbContext, bool, Task<User>> GetFirstCompiled =
    EF.CompileAsyncQuery((JoinForcesHubDbContext context, bool isTracking) =>
    isTracking == true ? context.Users.FirstOrDefault()
    : context.Users.AsNoTracking().FirstOrDefault());

    private readonly JoinForcesHubDbContext _context;

    public UserQueryRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.AnyAsync(predicate);
    }

    public int Count(Expression<Func<User, bool>> expression)
    {
        return _context.Users.Count(expression);
    }

    public IQueryable<User> GetAll(bool isTracking = true)
    {
        var result = _context.Users.AsQueryable();

        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }

    public async Task<User> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var query = await _context.Users.Where(e => e.Email == email).FirstOrDefaultAsync();

        return query;
    }

    public IQueryable<User> GetWhere(Expression<Func<User, bool>> expression, bool isTracking = true)
    {
        var result = _context.Users.Where(expression);

        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }

    public async Task<User> GetFirstExpression(Expression<Func<User, bool>> expression, bool isTracking = true)
    {
        if (isTracking)
        {
            return await _context.Users.FirstOrDefaultAsync(expression);
        }
        else
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(expression);
        }
    }
}
