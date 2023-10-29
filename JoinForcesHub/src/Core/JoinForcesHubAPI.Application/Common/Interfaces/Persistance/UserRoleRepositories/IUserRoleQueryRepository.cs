using System.Linq.Expressions;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

public interface IUserRoleQueryRepository
{
    Task<UserRole> GetFirst(bool isTracking = true);
    IQueryable<UserRole> GetAll(bool isTracking = true);
    int Count(Expression<Func<UserRole, bool>> expression);
    IQueryable<UserRole> GetWhere(Expression<Func<UserRole, bool>> expression, bool isTracking = true);
}
