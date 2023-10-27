using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinForcesHubAPI.Infrastructure.Persistence.EntityConfigurations.Users;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{

    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        throw new NotImplementedException();
    }
}
