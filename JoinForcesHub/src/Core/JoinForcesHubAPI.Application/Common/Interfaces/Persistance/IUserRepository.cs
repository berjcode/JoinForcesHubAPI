using JoinForcesHub.Domain.Entities.User;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    void Add(User user);
    User GetUserByEmail(string email); 

}
