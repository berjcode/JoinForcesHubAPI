using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore.Storage;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;

namespace JoinForcesHubAPI.Infrastructure.Services;

public class DbContextService : IDbContextService
{
    private readonly JoinForcesHubDbContext _context;

    public DbContextService(JoinForcesHubDbContext context)
    {
        _context = context;
    }

    public DbSet<User> Users => _context.Users;
    public DbSet<Role> Roles => _context.Roles;
    public DbSet<UserRole> UserRoles => _context.UserRoles;


    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
