using System.Data.Common;
using Lesson_6.Database;
using Lesson_6.Exceptions;
using Lesson_6.Models;
using Lesson_6.Services;
using Lesson_6.Services.Abstract;
class Program
{
    public void Run()
    {
        Product product1 = new Product
        {
            Id = BaseService.GenerateRandomId(3),
            Name = "Laptop",
            Description = "High performance laptop",
            Price = 1200.00
        };
        Product product2 = new Product
        {
            Id = BaseService.GenerateRandomId(3),
            Name = "Smartphone",
            Description = "Latest model smartphone",
            Price = 800.00
        };
        Product product3 = new Product
        {
            Id = BaseService.GenerateRandomId(3),
            Name = "Headphones",
            Description = "Noise-cancelling headphones",
            Price = 200.00
        };
        Product product4 = new Product
        {
            Id = BaseService.GenerateRandomId(3),
            Name = "Smartwatch",
            Description = "Fitness tracking smartwatch",
            Price = 250.00
        };
        Order order1 = new Order
        {
            Id = BaseService.GenerateRandomId(4),
            Products = new List<Product> { product1, product2 }
        };
        Order order2 = new Order
        {
            Id = BaseService.GenerateRandomId(4),
            Products = new List<Product> { product3, product4 }
        };
        Customer customer = new Customer
        {
            Id = BaseService.GenerateRandomId(5),
            Name = "John",
            Surname = "Doe",
            Password = "securepassword123",
            Orders = new List<Order> { order1, order2 }
        };

        StoreAppDB database = new StoreAppDB();
        database.Products.Add(product1);
        database.Products.Add(product2);
        database.Products.Add(product3);
        database.Products.Add(product4);
        database.Customers.Add(customer);
        database.Orders.Add(order1);
        database.Orders.Add(order2);

        IProductService productService = new ProductService(database);
        ICustomerService customerService = new CustomerService(database);
        IOrderService orderService = new OrderService(database);


        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome Store Application");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Login Customer");
                Console.Write("Enter the option: ");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option > 2 || option < 1)
                {
                    Console.WriteLine("Error: Invalid option selected. Please choose 1 or 2.\n");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("Enter your name: ");
                            string? name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                                throw new WrongInputException("Name cannot be empty.");

                            Console.Write("Enter your surname: ");
                            string? surname = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(surname))
                                throw new WrongInputException("Surname cannot be empty.");

                            Console.Write("Enter password: ");
                            string? password = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(password))
                                throw new WrongInputException("Password cannot be empty.");

                            customerService.Register(name, surname, password);
                            break;
                        }
                        break;
                    case 2:
                        Customer? loggedInCustomer = null;
                        while (true)
                        {
                            Console.Write("Enter your name: ");
                            string? loginName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(loginName))
                                throw new WrongInputException("Name cannot be empty.");

                            Console.Write("Enter password: ");
                            string? loginPassword = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(loginPassword))
                                throw new WrongInputException("Password cannot be empty.");

                            loggedInCustomer = customerService.Login(loginName, loginPassword);
                            if (loggedInCustomer != null)
                            {
                                Console.WriteLine($"Welcome {loggedInCustomer.Name} {loggedInCustomer.Surname}!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid credentials. Please try again.\n");
                            }
                        }
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("\n--- Order Management ---");
                            Console.WriteLine("1. Show all products");
                            Console.WriteLine("2. Add product");
                            Console.WriteLine("3. Update product");
                            Console.WriteLine("4. Delete product");
                            Console.WriteLine("5. Show all customers");
                            Console.Write("Select an option: ");
                            int orderOption = Convert.ToInt32(Console.ReadLine());

                            switch (orderOption)
                            {
                                case 1:
                                    Console.WriteLine("\vOrders: ");
                                    foreach (var order in orderService.GetAll())
                                    {
                                        Console.WriteLine($"Order ID: {order.Id}");
                                        foreach (var product in order.Products)
                                        {
                                            Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                                        }
                                    }
                                    break;
                                case 2:
                                    string? name, description;
                                    double price;
                                    Console.Write("Enter products name: ");
                                    name = Console.ReadLine();
                                    Console.Write("Enter products description: ");
                                    description = Console.ReadLine();
                                    Console.Write("Enter products price: ");
                                    price = double.Parse(Console.ReadLine());
                                    database.Products.Add(new Product
                                    {
                                        Id = BaseService.GenerateRandomId(3),
                                        Name = name,
                                        Description = description,
                                        Price = price
                                    });
                                    break;
                                case 3:
                                    Console.Write("Enter product ID to update: ");
                                    int updateId = Convert.ToInt32(Console.ReadLine());
                                    productService.Update(updateId);
                                    break;
                                case 4:
                                    Console.WriteLine("Enter product ID to delete: ");
                                    database.Products.RemoveAll(p => p.Id == Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 5:
                                    Console.WriteLine("\vCustomers: ");
                                    foreach (Customer customerItem in customerService.GetAll())
                                    {
                                        customerItem.Display();
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Wrong input. Please enter option between 1-5");
                                    break;
                            }

                        }
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid input format. Please enter a valid number. {ex.Message}\n");
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine($"Error: Customer not found. {ex.Message}\n");
            }
            catch (EmptyListException ex)
            {
                Console.WriteLine($"Error: List is empty. {ex.Message}\n");
            }
            catch (LoginErrorException ex)
            {
                Console.WriteLine($"Error: Login failed. {ex.Message}\n");
            }
            catch (OrderNotFoundException ex)
            {
                Console.WriteLine($"Error: Order not found. {ex.Message}\n");
            }
            catch (PasswordAlreadyUsedException ex)
            {
                Console.WriteLine($"Error: Password already used. {ex.Message}\n");
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"Error: Product not found. {ex.Message}\n");
            }
            catch (WrongInputException ex)
            {
                Console.WriteLine($"Error: Wrong input. {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}\n");
            }
        }

    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}