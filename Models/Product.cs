namespace Lesson_6.Models;

public class Product : BaseModel
{

    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public void Display()
    {
        Console.WriteLine($"Name: {Name}.  Description: {Description}.  Price: {Price}");
    }
}
