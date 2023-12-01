namespace JoinForcesHubAPI.Application.Utilities.Messages;

public static class ServiceExceptionMessages
{
    // User
    public static string InvalidPassword = "Invalid Password";
    public static string ThisUserNotRegister = "There is no such user";
    public static string UserAlreadyRegistered = "This username is already registered.";
    public static string UserWithGivenEmailNotExist = "User with given email does not exist";

    // Role
    public static string  RoleAlreadyRegistered="This Role is already registered";
    // File
    public static string FileNotBeEmpty = "file cannot be empty";


    //Methods
    public static void HandleException(Exception ex)
    {
        throw new Exception($"An Error Encountered  : {ex.Message}",ex);
    }
    public static void HandleException(string errorMessage)
    {
        throw new Exception($"An Error Encountered  : {errorMessage}");
    }
}