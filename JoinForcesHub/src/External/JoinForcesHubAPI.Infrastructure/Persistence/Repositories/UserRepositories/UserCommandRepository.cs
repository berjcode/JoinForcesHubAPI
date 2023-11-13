using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

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
        if (await _context.Users.AddAsync(user) != null)
            return true;

        return false;
    }

    public async Task AddRangeAsync(IEnumerable<User> user, CancellationToken cancellationToken)
    {
        await _context.Users.AddRangeAsync(user, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);

        _context.SaveChanges();
    }


    public void RemoveRange(IEnumerable<User> user)
    {
        _context.Users.RemoveRange(user);

        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void UpdateRange(IEnumerable<User> user)
    {
        _context.Users.UpdateRange(user);
        _context.SaveChanges();
    }
}
