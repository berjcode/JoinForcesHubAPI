﻿namespace JoinForcesHubAPI.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime NowTime { get; }
}
