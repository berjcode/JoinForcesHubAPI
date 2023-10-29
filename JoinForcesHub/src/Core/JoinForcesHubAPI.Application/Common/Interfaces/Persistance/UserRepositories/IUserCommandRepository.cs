using JoinForcesHub.Domain.Entities.User;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

public interface IUserCommandRepository
{
    void Update(User user);
    void Remove(User user);
    Task<bool> AddAsync(User user);
    void UpdateRange(IEnumerable<User> user);
    void RemoveRange(IEnumerable<User> user);
    Task AddRangeAsync(IEnumerable<User> user, CancellationToken cancellationToken);
}


