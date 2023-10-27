using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinForcesHubAPI.Infrastructure.Persistence.EntityConfigurations.Users;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    private const string userRoleTableName = "UserRoles";
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(us => us.Id);
        builder.ToTable(userRoleTableName);
        builder.Property(us => us.UserId).IsRequired();
        builder.Property(us => us.RoleId).IsRequired();

        //RelationShip
        builder.HasOne<User>(ur => ur.Users)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.HasOne<Role>(ur => ur.Roles)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // BaseEntitiy Configuration
        builder.Property(v => v.IsActive).IsRequired(true);
        builder.Property(v => v.UpdatedDate).IsRequired(false);
        builder.Property(v => v.UpdatedDate).IsRequired(false);
        builder.Property(v => v.IsDeleted).IsRequired(false);
        builder.Property(v => v.CreationDate).IsRequired(true);
        builder.Property(v => v.CreatedByUserName).IsRequired(true);
        builder.Property(v => v.UpdatedByUserName).IsRequired(false);
    }
}
