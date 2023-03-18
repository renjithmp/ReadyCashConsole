using LoanCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using LoanCore;
using LoanCore.Actions;
using CustomerCore.Model;
using CustomerCore.Actions;

namespace ReadyCashUnitTest;

[TestClass]
public class CustomerCrudUnitTests:BaseTest
{
    
    CustomerActions customerActions;

    public CustomerCrudUnitTests():base()
    {

        customerActions = new CustomerActions(customerDbContext);

    }

    [TestMethod]
    public void TestAddCustomer()
    {
        Customer customer = new Customer("name1", "email1.gmail.com", "112323232", "address1");
        customerActions.Add(customer);
        List<Customer> customers = customerActions.FindByName("name1");

        Assert.IsTrue(customers.Count > 0);
    }

    [TestMethod]
    public void TestRemoveCustomer()
    {
        string randomName = Guid.NewGuid().ToString();
        Customer customer = new Customer(randomName, "email1.gmail.com", "112323232", "address1");
        customerActions.Add(customer);
        customerActions.Remove(customer);
        List<Customer> customers = customerActions.FindByName(randomName);

        Assert.IsTrue(customers.Count == 0);
    }

    [TestMethod]
    public void TestUpdateCustomer()
    {
        Customer customer = new Customer("renjith", "email1.gmail.com", "112323232", "address1");
        customerActions.Update(customer);

        List<Customer> customers = customerActions.FindByName("renjith");

        Assert.IsTrue(customers.Count > 0);

    }


}
