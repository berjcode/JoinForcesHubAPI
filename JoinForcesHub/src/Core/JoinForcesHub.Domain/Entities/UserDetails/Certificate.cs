using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class Certificate :BaseEntity
{
    public Guid UserId { get; private set; }
    public string CertificateName { get; private set; }
    public string CertificateUrl { get; private set; }
    public string CertificateType { get; private set; }
    public DateTime  StartDate { get; private set; }
    public DateTime EndTime { get; private set; }
}
