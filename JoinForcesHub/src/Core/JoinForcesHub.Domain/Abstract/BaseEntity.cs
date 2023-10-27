namespace JoinForcesHub.Domain.Abstract;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public string CreatedByUserName { get; set; } = "Admin";
    public DateTime? UpdatedDate { get; set; } = null;
    public string UpdatedByUserName { get; set; } = null;
    public virtual DateTime? DeletedAt { get; set; } = null;
    public virtual bool? IsActive { get; set; } = true;
    public virtual bool? IsDeleted { get; set; } = false;
}
