using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinForcesHubAPI.Infrastructure.Persistence.EntityConfigurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    private const string nvarcharFiftyteenExpressionOption = "nvarchar(50)";
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.RoleName).HasColumnType(nvarcharFiftyteenExpressionOption).IsRequired();
        builder.Property(u => u.Description).HasColumnType(nvarcharFiftyteenExpressionOption).IsRequired();
    }
}
