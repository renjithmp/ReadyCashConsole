// See https://aka.ms/new-console-template for more information
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

string customerDBConnectionstring = "Host=localhost; Database=customer; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;
string loanDBConnectionstring = "Host=localhost; Database=loan; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;
using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
//services.AddDbContext<BankDbContext>(options => options.UseNpgsql(ConfigurationManager.ConnectionStrings["localPgsql"].ConnectionString))
//).Build();
services.AddSingleton<ReadyCashKafkaProducer>().
AddDbContext<CustomerDbContext>(options => options.UseNpgsql(customerDBConnectionstring)).AddDbContext<LoanDbContext>(options=>
options.UseNpgsql(loanDBConnectionstring))
).Build();
host.StartAsync();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var readyCashKafkaProducer = provider.GetService<ReadyCashKafkaProducer>();
readyCashKafkaProducer.SendMessage();
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