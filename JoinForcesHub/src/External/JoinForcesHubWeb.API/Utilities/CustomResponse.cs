namespace JoinForcesHubWeb.API.Utilities;

public class CustomResponse
{
    public CustomResponse(int statusCode, string message, string details =null)
    {
        Details = details;
        Message = message;
        StatusCode = statusCode;
    }

    public string Message { get; set; }
    public string Details { get; set; }
    public int StatusCode { get; set; }
}
