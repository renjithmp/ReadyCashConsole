// See https://aka.ms/new-console-template for more information
using ReadyCashConsole;
using ReadyCashConsole.Model;

Console.WriteLine("Hello, World!");
CustomerCRUD customerCRUD = new CustomerCRUD(new BankDbContext());
Customer customer = new Customer();
customer.Address = "address1";
customer.Email = "email1@gmail.com";
customer.Name = "name1";
customer.Phone = "1212121212";
List<Customer> customers= customerCRUD.Read();
Console.ReadLine();
