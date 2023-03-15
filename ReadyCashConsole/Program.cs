// See https://aka.ms/new-console-template for more information
using System.Configuration;
using Bank.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadyCashConsole;
using ReadyCashConsole.Model;
using ReadyCashConsole.Actions;
    
using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
//services.AddDbContext<BankDbContext>(options => options.UseNpgsql(ConfigurationManager.ConnectionStrings["localPgsql"].ConnectionString))
//).Build();
services.AddDbContext<BankDbContext>(options => options.UseNpgsql("Host=localhost; Database=readycash; Username=webuser; Password=SocGen01*"))
).Build();
host.StartAsync();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

Console.WriteLine("Hello, World!");
var bankDbContext = provider.GetService<BankDbContext>();
if (bankDbContext != null)
{
    CustomerActions customerCRUD = new CustomerActions(provider.GetService<BankDbContext>());
    Customer customer = new Customer("name1", "email1.gmail.com", "112323232", "address1");
    customerCRUD.Add(customer);
    Console.ReadLine();
}