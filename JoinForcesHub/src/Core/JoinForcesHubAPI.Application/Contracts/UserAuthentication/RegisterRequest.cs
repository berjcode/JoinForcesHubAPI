namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record RegisterRequest(
    string FirstName,
    string SurName,
    string UserName,
    string Email,
    string About,
    string PasswordHash,
    string PhotoPath,
    string GithubLink,
    string LinkedlnLink,
    string StackOverFlowLink,
    string Location,
    string EducationStatus,
    string JobStatus,
    bool IsProfileVisible,
    string CoverPhoto,
    bool IsPremium
    );
