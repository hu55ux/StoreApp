namespace Lesson_6.Exceptions;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException(int orderId)
        : base($"Order with ID {orderId} not found.")
    {
    }
    public OrderNotFoundException(string customerName)
        : base($"Order for customer '{customerName}' not found.")
    {
    }
}
