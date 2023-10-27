using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Teams;

public class Team : BaseEntity
{
    public string TeamName { get;  set; }
    public string TeamDescription { get;  set; }
    public string TeamSlogan { get;  set; }

}
