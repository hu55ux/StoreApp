using Lesson_6.Helper;
using Lesson_6.Models;

namespace Lesson_6.Database;

public class StoreAppDB
{
    public List<Customer> Customers { get; set; }
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; }

    private string jsonProducts = "products.json";
    private string jsonOrders = "orders.json";
    private string jsonCustomers = "customers.json";
    public StoreAppDB()
    {
        Customers = new List<Customer>();
        Products = new List<Product>();
        Orders = new List<Order>();
        Products = JsonHelper.LoadFromJson<Product>(jsonProducts);
        Orders = JsonHelper.LoadFromJson<Order>(jsonOrders);
    }
    public void SaveAll()
    {
        JsonHelper.SaveToJson(Products, jsonProducts);
        JsonHelper.SaveToJson(Orders, jsonOrders);
        JsonHelper.SaveToJson(Customers, jsonCustomers);
    }
}
