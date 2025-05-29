namespace Lesson_6.Exceptions;

public class WrongInputException : Exception
{
    public WrongInputException(string message)
        : base(message)
    {
    }
   public WrongInputException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}
