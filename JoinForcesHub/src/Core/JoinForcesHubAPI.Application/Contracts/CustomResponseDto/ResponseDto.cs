using System.Text.Json.Serialization;

namespace JoinForcesHubAPI.Application.Contracts.CustomResponseDto;

public class ResponseDto<T>
{
    public T Result { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }

    [JsonIgnore]
    public int StatusCode { get; private set; }
    [JsonIgnore]
    public bool IsSuccessful { get; private set; }

    public static ResponseDto<T> Success(T Data, int statusCode)
    {
        return new ResponseDto<T> { Result = Data, StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseDto<T> Success(T data, int statusCode, string message)
    {
        return new ResponseDto<T> { Result = data, StatusCode = statusCode, Message = message, IsSuccessful = true };
    }
    public static ResponseDto<T> Success(int statusCode)
    {
        return new ResponseDto<T> { Result = default(T), StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseDto<T> IsSuccess(T Data, int statusCode, string message)
    {
        return new ResponseDto<T> { Result = default(T), Message = message, StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseDto<T> Fail(List<string> errors, int statusCode)
    {
        return new ResponseDto<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
    }
    public static ResponseDto<T> Fail(string error, int statusCode)
    {
        return new ResponseDto<T> { Errors = new List<string>() { error }, StatusCode = statusCode, };
    }
}
