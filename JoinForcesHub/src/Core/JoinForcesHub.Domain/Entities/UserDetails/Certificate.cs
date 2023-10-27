using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class Certificate : BaseEntity
{
    public Guid UserId { get;  set; }
    public string CertificateName { get;  set; }
    public string CertificateUrl { get;  set; }
    public string CertificateType { get;  set; }
    public DateTime StartDate { get;  set; }
    public DateTime EndTime { get;  set; }
}
