using Lesson_6.Database;
using Lesson_6.Exceptions;
using Lesson_6.Models;
using Lesson_6.Services.Abstract;

namespace Lesson_6.Services;

public class ProductService : BaseService, IProductService
{
    public ProductService(StoreAppDB database) : base(database)
    {
    }

    public void Add(Product item)
    {
        _database.Products.Add(item);
    }

    public void Delete(int id)
    {
        var item = _database.Products.FirstOrDefault(p => p.Id == id);
        if (item != null)
        {
            _database.Products.Remove(item);
        }
        else
        {
            throw new ProductNotFoundException(id);
        }
    }

    public List<Product> GetAll()
    {
        return _database.Products;
    }

    public Product GetById(int id)
    {
        var item = _database.Products.FirstOrDefault(p => p.Id == id);
        if (item != null)
        {
            return item;
        }
        else
        {
            throw new ProductNotFoundException(id);
        }
    }

    

    public bool isValid(Product item)
    {
        if (string.IsNullOrEmpty(item.Name) || item.Name.Length <= 2 || string.IsNullOrEmpty(item.Description) || item.Price <= 0)
        {
            return false;
        }
        return true;

    }

    public void Update(int id)
    {
        var item = _database.Products.FirstOrDefault(p => p.Id == id);
        if (item != null)
        {
            string? name, description;
            double price;
            Console.WriteLine($"Enter new name for product (current: {item.Name}): ");
            name = Console.ReadLine()?.Trim() ?? item.Name;
            Console.WriteLine($"Enter new description for product (current: {item.Description}): ");
            description = Console.ReadLine()?.Trim() ?? item.Description;
            Console.WriteLine($"Enter new price for product (current: {item.Price}): ");
            if (!double.TryParse(Console.ReadLine()?.Trim(), out price) || price <= 0)
            {
                price = item.Price;
            }
            item.Name = name;
            item.Description = description;
            item.Price = price;
            _database.Products.Remove(item);
            _database.Products.Add(item);
        }
        else
        {
            throw new ProductNotFoundException(id);
        }
    }
}
