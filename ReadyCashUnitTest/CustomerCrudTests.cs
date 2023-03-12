using Bank.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ReadyCashConsole;
using ReadyCashConsole.Model;

namespace ReadyCashUnitTest;

[TestClass]
public class CustomerCrudUnitTests
{
    BankDbContext bankDbContext;
    CustomerActions customerCRUD;

    public CustomerCrudUnitTests()
    {

        DbContextOptionsBuilder dbContextOptions = new DbContextOptionsBuilder();
        dbContextOptions.UseInMemoryDatabase(databaseName: "inMemoryReadyCashDb");
        bankDbContext = new BankDbContext(dbContextOptions.Options);
        customerCRUD = new CustomerActions(bankDbContext);

    }

    [TestMethod]
    public void TestAddCustomer()
    {
        Customer customer = new Customer("name1", "email1.gmail.com", "112323232", "address1");
        customerCRUD.Add(customer);
        List<Customer> customers = customerCRUD.FindByName("name1");

        Assert.IsTrue(customers.Count > 0);
    }

    [TestMethod]
    public void TestRemoveCustomer()
    {
        Customer customer = new Customer("name1", "email1.gmail.com", "112323232", "address1");

        customerCRUD.Remove(customer);
        List<Customer> customers = customerCRUD.FindByName("name1");

        Assert.IsTrue(customers.Count == 0);
    }

    [TestMethod]
    public void TestUpdateCustomer()
    {
        Customer customer = new Customer("renjith", "email1.gmail.com", "112323232", "address1");
        customerCRUD.Update(customer);

        List<Customer> customers = customerCRUD.FindByName("renjith");

        Assert.IsTrue(customers.Count > 0);

    }

    //public DbContextOptionsBuilder GetDbContextOptionsBuilder()
    //{
    //    var dbContextOptionsBuilder = new DbContextOptionsBuilder();

    //    IOptions<MemoryCacheOptions> options = null;
    //    IMemoryCache memoryCache = new MemoryCache(options);
    //    dbContextOptionsBuilder.UseMemoryCache(memoryCache);
    //    return dbContextOptionsBuilder;
    //}
}
