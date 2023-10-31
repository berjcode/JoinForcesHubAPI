using System.Linq.Expressions;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

public interface IRoleQueryRepository
{
    Task<Role> GetFirst(bool isTracking = true);
    IQueryable<Role> GetAll(bool isTracking = true);
    Task<int> Count(Expression<Func<Role, bool>> expression);
    Task<Role> GetFirstExpression(Expression<Func<Role, bool>> expression, bool isTracking = true);
    IQueryable<Role> GetWhere(Expression<Func<Role, bool>> expression, bool isTracking = true);
}
