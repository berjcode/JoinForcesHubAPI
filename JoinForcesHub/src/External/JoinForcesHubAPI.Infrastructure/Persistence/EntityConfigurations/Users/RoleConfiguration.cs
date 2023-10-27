using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinForcesHubAPI.Infrastructure.Persistence.EntityConfigurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    private const string roleTableName = "Roles";
    private const string nvarcharFiftyteenExpressionOption = "nvarchar(50)";
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(u => u.Id);
        builder.ToTable(roleTableName);
        builder.Property(u => u.RoleName).HasColumnType(nvarcharFiftyteenExpressionOption).IsRequired();
        builder.Property(u => u.Description).HasColumnType(nvarcharFiftyteenExpressionOption).IsRequired();

        // BaseEntitiy Configuration
        builder.Property(v => v.IsActive).IsRequired(true);
        builder.Property(v => v.UpdatedDate).IsRequired(false);
        builder.Property(v => v.UpdatedDate).IsRequired(false);
        builder.Property(v => v.IsDeleted).IsRequired(false);
        builder.Property(v => v.DeletedAt).IsRequired(false);
        builder.Property(v => v.CreationDate).IsRequired(true);
        builder.Property(v => v.CreatedByUserName).IsRequired(true);
        builder.Property(v => v.UpdatedByUserName).IsRequired(false);
    }
}
