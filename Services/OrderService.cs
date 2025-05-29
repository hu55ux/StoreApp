using Lesson_6.Database;
using Lesson_6.Exceptions;
using Lesson_6.Models;
using Lesson_6.Services.Abstract;

namespace Lesson_6.Services;

public class OrderService : BaseService, IOrderService
{
    public OrderService(StoreAppDB database) : base(database)
    {
    }

    public void Add(Order item)
    {
        _database.Orders.Add(item);
    }

    public void Delete(int id)
    {
        var order = _database.Orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            _database.Orders.Remove(order);
        }
        else
        {
            throw new OrderNotFoundException(id);
        }
    }

    public List<Order> GetAll()
    {
        return _database.Orders.ToList();
    }

    public Order GetById(int id)
    {
        var order = _database.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            throw new OrderNotFoundException(id);
        }
        return order;
    }
    public void DeleteAll()
    {
        _database.Orders.Clear();
    }
}
