using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Teams;

public class TeamAnnouncement :BaseEntity
{
    public Guid TeamId { get;  set; }
    public string Title { get;  set; }
    public string Description { get;  set; } 
}
