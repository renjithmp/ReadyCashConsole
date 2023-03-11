// See https://aka.ms/new-console-template for more information
using Bank.Model;
using ReadyCashConsole;
using ReadyCashConsole.Model;

Console.WriteLine("Hello, World!");
CustomerActions customerCRUD = new CustomerActions(new BankDbContext());
Customer customer = new Customer("name1","email1.gmail.com","112323232","address1");
customerCRUD.Add(customer);
Console.ReadLine();
