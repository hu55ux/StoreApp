namespace Lesson_6.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(int productId)
        : base($"Product with ID {productId} not found.")
    {
    }
    public ProductNotFoundException(string productName)
        : base($"Product with name '{productName}' not found.")
    {
    }
}
