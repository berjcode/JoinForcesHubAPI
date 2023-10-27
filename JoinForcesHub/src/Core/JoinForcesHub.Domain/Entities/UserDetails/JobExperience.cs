using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class JobExperience : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Description { get; private set; }
    public string PositionName { get; private set; }
    public string CompanyName { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
}
