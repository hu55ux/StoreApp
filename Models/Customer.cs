using Lesson_6.Exceptions;

namespace Lesson_6.Models;

public class Customer : BaseModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Password { get; set; }
    public List<Order>? Orders { get; set; }
    public void Display()
    {
        if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Surname))
        {
            throw new EmptyListException("Name and Surname cannot be null or empty.");
        }
        Console.WriteLine($"Name: {Name}.  Surname: {Surname}.");
        if (Orders == null || !Orders.Any())
        {
           throw new EmptyListException("Orders list cannot be null or empty.");
        }
        Console.WriteLine($"Customer has {Orders.Count} orders.");
        foreach (var order in Orders)
        {
            order.Display();
        }
    }
}
