using Microsoft.AspNetCore.Http;

namespace JoinForcesHubAPI.Application.Contracts.UserAuthentication;

public record RegisterRequest(
    string FirstName,
    string SurName,
    string UserName,
    string UserJobTitle,
    string Email,
    string About,
    string PasswordHash,
    string GithubLink,
    string LinkedlnLink,
    string StackOverFlowLink,
    string Location,
    string EducationStatus,
    string JobStatus,
    bool IsProfileVisible,
    bool IsPremium,
    IFormFile UserProfilePicture,
    IFormFile UserCoverPicture
    );
