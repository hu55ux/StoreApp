namespace Lesson_6.Exceptions;

class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(string message) : base(message)
    {

    }
    public CustomerNotFoundException(int customerId)
        : base($"Customer with ID {customerId} not found.")
    {
    }
   
}

