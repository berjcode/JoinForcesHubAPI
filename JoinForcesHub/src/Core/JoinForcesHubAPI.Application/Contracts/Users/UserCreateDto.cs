﻿namespace JoinForcesHubAPI.Application.Contracts.Users;

public record UserCreateDto(
    string FirstName,
    string SurName,
    string UserName,
    string Email,
    string About,
    string UserJobTitle,
    string Password,
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
