using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Teams;

public class Team : BaseEntity
{
    public string TeamName { get; private set; }
    public string TeamDescription { get; private set; }
    public string TeamSlogan { get; private set; }

}
