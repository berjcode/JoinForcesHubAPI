using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinForcesHubAPI.Infrastructure.Persistence.EntityConfigurations.Users;

public sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    private const string usersTableName = "Users";
    private const string bitExpressionOption = "bit";
    private const string nvarcharMaxExpressionOption = "nvarchar(max)";
    private const string nvarcharFifteenExpressionOption = "nvarchar(50)";
    private const string nvarcharHundredExpressionOption = "nvarchar(100)";
    private const string nvarcharFiftySevenExpressionOption = "nvarchar(25)";
    private const string nvarcharFiveHundredExpressionOption = "nvarchar(500)";
    private const string nvarcharThreeHundredExpressionOption = "nvarchar(300)";
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.ToTable(usersTableName);
        builder.Property(u => u.IsPremium).HasColumnType(bitExpressionOption).IsRequired();
        builder.Property(u => u.IsProfileVisible).HasColumnType(bitExpressionOption).IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnType(nvarcharMaxExpressionOption).IsRequired();
        builder.Property(u => u.PhotoPath).HasColumnType(nvarcharMaxExpressionOption).IsRequired();
        builder.Property(u => u.CoverPhoto).HasColumnType(nvarcharMaxExpressionOption).IsRequired();
        builder.Property(u => u.Location).HasColumnType(nvarcharHundredExpressionOption).IsRequired();
        builder.Property(u => u.SurName).HasColumnType(nvarcharFiftySevenExpressionOption).IsRequired();
        builder.Property(u => u.UserName).HasColumnType(nvarcharFiftySevenExpressionOption).IsRequired();
        builder.Property(u => u.UserName).HasColumnType(nvarcharFiftySevenExpressionOption).IsRequired();
        builder.Property(u => u.JobStatus).HasColumnType(nvarcharFiftySevenExpressionOption).IsRequired();
        builder.Property(u => u.FirstName).HasColumnType(nvarcharFiftySevenExpressionOption).IsRequired();
        builder.Property(u => u.About).HasColumnType(nvarcharFiveHundredExpressionOption).IsRequired(false);
        builder.Property(u => u.EducationStatus).HasColumnType(nvarcharFifteenExpressionOption).IsRequired();
        builder.Property(u => u.GithubLink).HasColumnType(nvarcharThreeHundredExpressionOption).IsRequired(false);
        builder.Property(u => u.LinkedlnLink).HasColumnType(nvarcharThreeHundredExpressionOption).IsRequired(false);
        builder.Property(u => u.StackOverFlowLink).HasColumnType(nvarcharThreeHundredExpressionOption).IsRequired(false);

        // BaseEntitiy Configuration
        builder.Property(v => v.IsActive).IsRequired(true);
        builder.Property(v => v.IsDeleted).IsRequired(false);
        builder.Property(v => v.DeletedAt).IsRequired(false);
        builder.Property(v => v.CreationDate).IsRequired(true);
        builder.Property(v => v.UpdatedDate).IsRequired(false);
        builder.Property(v => v.UpdatedDate).IsRequired(false);
        builder.Property(v => v.CreatedByUserName).IsRequired(true);
        builder.Property(v => v.UpdatedByUserName).IsRequired(false);
    }
}
