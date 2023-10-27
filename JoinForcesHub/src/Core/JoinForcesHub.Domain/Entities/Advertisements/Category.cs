using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Advertisements;

public class Category :BaseEntity
{
    public string CategoryName { get;  set; }
    public string Description { get;  set; }
}
