namespace Lesson_6.Exceptions;

public class PasswordAlreadyUsedException: Exception
{
    public PasswordAlreadyUsedException()
        : base("This password has already been used.") { }

    public PasswordAlreadyUsedException(string message)
        : base(message) { }
}
