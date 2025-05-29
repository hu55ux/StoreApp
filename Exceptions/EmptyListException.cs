namespace Lesson_6.Exceptions;

public class EmptyListException: Exception
{
    public EmptyListException() : base("The list is empty.")
    {
    }
    public EmptyListException(string message) : base(message)
    {
    }
    public EmptyListException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

