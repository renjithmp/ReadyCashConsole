using System;
using System.Linq;
using CustomerCore.Model;


namespace CustomerCore.Actions

{
/// <summary>
/// Represents a class that performs various actions related to customers.
/// </summary>
public class CustomerActions
{
    readonly CustomerDbContext bankDbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerActions"/> class.
    /// </summary>
    /// <param name="bankDbContext">The database context for customers.</param>
    public CustomerActions(CustomerDbContext bankDbContext)
    {
        this.bankDbContext = bankDbContext;
    }

    /// <summary>
    /// Adds a new customer to the database.
    /// </summary>
    /// <param name="customer">The customer to add.</param>
    public void Add(Customer customer)
    {
        this.bankDbContext.Add<Customer>(customer);
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Removes a customer from the database.
    /// </summary>
    /// <param name="customer">The customer to remove.</param>
    public void Remove(Customer customer)
    {
        this.bankDbContext.Remove<Customer>(customer);
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Removes customers with the specified name from the database.
    /// </summary>
    /// <param name="name">The name of the customers to remove.</param>
    public void RemoveByName(string name)
    {
        var customers = this.bankDbContext.Customers.Where(customer => customer.Name.Equals(name)).ToList<Customer>();
        this.bankDbContext.Remove(customers);
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Updates a customer in the database.
    /// </summary>
    /// <param name="customer">The customer to update.</param>
    public void Update(Customer customer)
    {
        this.bankDbContext.Update<Customer>(customer);
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Retrieves all customers from the database.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    public List<Customer> Read()
    {
        return this.bankDbContext.Customers.ToList<Customer>();
    }

    /// <summary>
    /// Finds customers with the specified name in the database.
    /// </summary>
    /// <param name="name">The name of the customers to find.</param>
    /// <returns>A list of customers with the specified name.</returns>
    public List<Customer> FindByName(string name)
    {
        return this.bankDbContext.Customers.Where(cust => cust.Name.Equals(name)).ToList<Customer>();
    }
}
}

