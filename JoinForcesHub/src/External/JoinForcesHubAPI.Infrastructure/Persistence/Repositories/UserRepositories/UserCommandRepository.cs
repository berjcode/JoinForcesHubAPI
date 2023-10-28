using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRepositories;


public sealed class UserCommandRepository : IUserCommandRepository
{
    private readonly JoinForcesHubDbContext _context;

    public UserCommandRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(User user)
    {

        await _context.Users.AddAsync(user);

        if (await _context.SaveChangesAsync() > 0)
            return true;

        return false;
    }



    public Task<bool> HardDeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SoftDeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
