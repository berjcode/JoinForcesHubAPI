using JoinForcesHub.Domain.Entities.User;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance;

public interface IUserCommandRepository
{
    Task<bool> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> HardDeleteByIdAsync(Guid id);
    Task<bool> SoftDeleteByIdAsync(Guid id);
}
