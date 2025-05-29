using Lesson_6.Models;

namespace Lesson_6.Services.Abstract;

interface ICustomerService
{
    public List<Customer> GetAll();
    public Customer GetById(int id);
    public void Add(Customer item);
    public void Update(int id);
    public void Delete(int id);
    public Customer? Login(string name, string password);
    public void Register(string name, string surname, string password);


}
