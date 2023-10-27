using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class EducationExperience : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Description { get; private set; }
    public string SchoolName { get; private set; }
    public string SchoolDescription { get; private set; }
    public string DepartmentName { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; set; }
    public decimal Gno { get; private set; }
}
