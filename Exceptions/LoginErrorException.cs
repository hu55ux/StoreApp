namespace Lesson_6.Exceptions;

public class LoginErrorException: Exception
{
    public LoginErrorException(string message) : base(message)
    {
    }
    public LoginErrorException() : base("Login error occurred.")
    {
    }
}
