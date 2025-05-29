using Lesson_6.Models;

namespace Lesson_6.Services.Abstract;

interface IOrderService
{
    public List<Order> GetAll();
    public Order GetById(int id);
    public void Add(Order item);
    public void Delete(int id);
    public void DeleteAll();

}
