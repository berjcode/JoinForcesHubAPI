namespace JoinForcesHub.Domain.Abstract;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime  CreationDate  { get; set; }
    public string CreatedByUserName { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string UpdatedByUserName { get; set; }
    public bool  IsActive  { get; set; }
    public bool  IsDeleted  { get; set; }
}
