using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class EducationExperience : BaseEntity
{
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public string SchoolName { get; set; }
    public string SchoolDescription { get; set; }
    public string DepartmentName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Gno { get; set; }
}
