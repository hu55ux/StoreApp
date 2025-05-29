using Lesson_6.Models;

namespace Lesson_6.Services.Abstract;

interface IProductService
{
    public List<Product> GetAll();
    public Product GetById(int id);
    public void Add(Product item);
    public void Update(int id);
    public void Delete(int id);
    public bool isValid(Product item);
}
