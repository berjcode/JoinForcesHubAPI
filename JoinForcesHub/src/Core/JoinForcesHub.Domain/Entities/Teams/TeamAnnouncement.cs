using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Teams;

public class TeamAnnouncement :BaseEntity
{
    public Guid TeamId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; } 
}
