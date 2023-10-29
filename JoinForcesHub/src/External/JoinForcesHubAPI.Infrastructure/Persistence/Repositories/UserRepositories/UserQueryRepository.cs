using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Repositories.UserRepositories;

public class UserQueryRepository : IUserQueryRepository
{

    private readonly JoinForcesHubDbContext _context;

    public UserQueryRepository(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var query = await _context.Users.Where(e => e.Email == email).FirstOrDefaultAsync();

        return query;
    }
}
