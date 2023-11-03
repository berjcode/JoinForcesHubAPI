using System.Linq.Expressions;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHub.Domain.Entities.User;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

public interface IUserQueryRepository
{
    Task<User> GetUserByEmail(string email);
    Task<User> GetFirst(bool isTracking = true);
    IQueryable<User> GetAll(bool isTracking = true);
    int Count(Expression<Func<User, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
    Task<User> GetFirstExpression(Expression<Func<User, bool>> expression, bool isTracking = true);
    IQueryable<User> GetWhere(Expression<Func<User, bool>> expression, bool isTracking = true);
}
