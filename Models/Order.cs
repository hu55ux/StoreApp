using Lesson_6.Exceptions;

namespace Lesson_6.Models;

public class Order : BaseModel
{
    public double TotalPrice => Products?.Sum(p => p.Price) ?? 0.00;
    public List<Product>? Products { get; set; }
    public void Display()
    {
        if (Products == null || !Products.Any())
        {
            throw new EmptyListException("Products list cannot be null or empty.");
        }
        Console.WriteLine($"Order has {Products.Count} products.");
        Console.WriteLine($"Total Price: {TotalPrice}");
        Console.WriteLine("Products in this order:");
        foreach (var product in Products)
        {
            product.Display();
        }
    }
}
