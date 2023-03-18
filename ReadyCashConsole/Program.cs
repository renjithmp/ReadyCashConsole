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

using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
//services.AddDbContext<BankDbContext>(options => options.UseNpgsql(ConfigurationManager.ConnectionStrings["localPgsql"].ConnectionString))
//).Build();
services.AddDbContext<CustomerDbContext>(options => options.UseNpgsql("Host=localhost; Database=readycash; Username=webuser; Password=SocGen01*"))
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