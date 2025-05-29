using Lesson_6.Models;

namespace Lesson_6.Database;

public class StoreAppDB
{
    public List<Customer> Customers { get; set; }
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; }
    public StoreAppDB()
    {
        Customers = new List<Customer>();
        Products = new List<Product>();
        Orders = new List<Order>();
    }
}
