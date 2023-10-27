using System.Reflection;
using Microsoft.EntityFrameworkCore;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Teams;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHub.Domain.Entities.Messages;
using JoinForcesHub.Domain.Entities.Advertisements;
using JoinForcesHub.Domain.Entities.UserDetails;

namespace JoinForcesHubAPI.Infrastructure.Persistence.Contexts;

public class JoinForcesHubDbContext : DbContext
{
    #region Ctor
    public JoinForcesHubDbContext(DbContextOptions<JoinForcesHubDbContext> options) : base(options)
    {
    }
    #endregion

    #region DbSet
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    //public DbSet<Advertisement> Advertisements { get; set; }
    //public DbSet<Category> Categories { get; set; }
    //public DbSet<AdvertisementCategory> AdvertisementsCategory { get; set; }
    //public DbSet<Message> Messages { get; set; }
    //public DbSet<Room> Rooms { get; set; }
    //public DbSet<UserRoom> UserRooms { get; set; }
    //public DbSet<Team> Teams { get; set; }
    //public DbSet<TeamAnnouncement> TeamsAnnouncements { get; set; }
    //public DbSet<TeamMembers> TeamsMembers { get; set; }
    //public DbSet<Advice> Advices { get; set; }
    //public DbSet<Certificate> Certificates { get; set; }
    //public DbSet<EducationExperience> EducationExperiences { get; set; }
    //public DbSet<JobExperience> JobExperiences { get; set; }
    //public DbSet<Project> Projects { get; set; }
    //public DbSet<ProjectGalery> ProjectGaleries { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
