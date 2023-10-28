using JoinForcesHub.Domain.Entities.User;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance;

public interface IUserQueryRepository
{
    Task<User> GetUserByEmail(string email);
}
