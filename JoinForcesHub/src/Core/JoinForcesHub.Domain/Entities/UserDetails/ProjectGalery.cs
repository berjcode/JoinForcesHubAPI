using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class ProjectGalery : BaseEntity
{
    public string PhotoPath { get; private set; }
    public bool Priority { get; private set; }
}
