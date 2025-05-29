using Lesson_6.Database;
namespace Lesson_6.Services;

public class BaseService
{
    protected StoreAppDB _database;
    public BaseService(StoreAppDB database)
    {
        _database = database;
    }
    public static int GenerateRandomId(int length = 5)
    {
        if (length < 1 || length > 9) throw new ArgumentOutOfRangeException(nameof(length), "Length must be between 1 and 9");
        var random = new Random();
        int min = (int)Math.Pow(10, length - 1);
        int max = (int)Math.Pow(10, length) - 1;
        return random.Next(min, max + 1);
    }
}
