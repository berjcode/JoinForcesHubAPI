using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class JobExperience : BaseEntity
{
    public Guid UserId { get; set; } 
    public string Description { get; set; }
    public string PositionName { get; set; }
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
