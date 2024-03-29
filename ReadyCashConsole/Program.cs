/*
 * This program is a prototype for a core banking system.
 * It demonstrates the usage of various components such as database connections, dependency injection, and messaging.
 * The program connects to two databases - customer and loan - using PostgreSQL.
 * It creates a Kafka producer for publishing customer transactions.
 * The program performs CRUD operations on the customer database using the CustomerActions class.
 * It adds a new customer to the database and prints "Hello, World!" to the console.
 */

using System.Configuration;
using LoanCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LoanCore;
using CustomerCore;
using CustomerCore.Actions;
using LoanCore.Actions;
using CustomerCore.Model;
using Messaging.Publisher;

string customerDBConnectionstring = "Host=localhost; Database=customer; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;
string loanDBConnectionstring = "Host=localhost; Database=loan; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;
using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
//services.AddDbContext<BankDbContext>(options => options.UseNpgsql(ConfigurationManager.ConnectionStrings["localPgsql"].ConnectionString))
//).Build();
services.AddSingleton<ReadyCashKafkaProducer<CustomerTransactions>>().
AddDbContext<CustomerDbContext>(options => options.UseNpgsql(customerDBConnectionstring)).AddDbContext<LoanDbContext>(options=>
options.UseNpgsql(loanDBConnectionstring))
).Build();
host.StartAsync();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;


Console.WriteLine("Hello, World!");
var bankDbContext = provider.GetService<CustomerDbContext>();
if (bankDbContext != null)
{
    CustomerDbContext customerDbContext = provider.GetService<CustomerDbContext>();
    if (customerDbContext != null)
    {
        CustomerActions customerCRUD = new CustomerActions(customerDbContext);
        Customer customer = new Customer("name1", "email1.gmail.com", "112323232", "address1");
        customerCRUD.Add(customer);
        Console.ReadLine();
    }
}