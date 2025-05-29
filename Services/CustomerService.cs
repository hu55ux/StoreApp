using Lesson_6.Database;
using Lesson_6.Exceptions;
using Lesson_6.Models;
using Lesson_6.Services.Abstract;

namespace Lesson_6.Services;

public class CustomerService : BaseService, ICustomerService
{
    public CustomerService(StoreAppDB database) : base(database) { }

    public void Add(Customer item)
    {
        _database.Customers.Add(item);
    }

    public void Delete(int id)
    {
        var customer = GetById(id); // throws if not found
        _database.Customers.Remove(customer);
    }

    public List<Customer> GetAll()
    {
        return _database.Customers.ToList();
    }

    public Customer GetById(int id)
    {
        var customer = _database.Customers.FirstOrDefault(p => p.Id == id);
        if (customer == null)
            throw new CustomerNotFoundException($"Customer with ID {id} not found.");
        return customer;
    }

    public Customer? Login(string name, string password)
    {
        return _database.Customers.FirstOrDefault(c =>
            c.Name == name && c.Password == password
        );
    }

    public void Register(string name, string surname, string password)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(password))
            throw new WrongInputException("Name, surname or password cannot be empty.");

        if (_database.Customers.Any(c => c.Password == password))
            throw new PasswordAlreadyUsedException("This password has already been used. Please choose a different one.");

        var newCustomer = new Customer
        {
            Id = GenerateRandomId(5),
            Name = name,
            Surname = surname,
            Password = password
        };

        _database.Customers.Add(newCustomer);
        Console.WriteLine($"Customer {name} {surname} registered successfully.");
    }

    public void Update(int id)
    {
        var customer = GetById(id);

        Console.WriteLine($"Enter new name (current: {customer.Name}): ");
        string? newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
            customer.Name = newName;

        Console.WriteLine($"Enter new surname (current: {customer.Surname}): ");
        string? newSurname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newSurname))
            customer.Surname = newSurname;

        Console.WriteLine("Enter current password to update your password: ");
        string currentPassword = Console.ReadLine() ?? string.Empty;

        if (currentPassword != customer.Password)
            throw new WrongInputException("Current password is incorrect.");

        Console.WriteLine("Enter new password: ");
        string? newPassword = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newPassword))
            throw new WrongInputException("New password cannot be empty.");

        if (_database.Customers.Any(c => c.Password == newPassword))
            throw new PasswordAlreadyUsedException("This password has already been used.");

        customer.Password = newPassword;

        Console.WriteLine($"Customer {customer.Name} {customer.Surname} updated successfully.");
    }


}

