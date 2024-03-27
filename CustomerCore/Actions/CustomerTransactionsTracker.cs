using System;
using System.Linq;
using CustomerCore.Model;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

namespace CustomerCore.Actions
{
    /// <summary>
    /// Represents a class that tracks customer transactions.
    /// </summary>
    public class CustomerTransactionsTracker
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private CustomerDbContext customerDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTransactionsTracker"/> class.
        /// </summary>
        /// <param name="scopeFactory">The service scope factory.</param>
        public CustomerTransactionsTracker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            var scope = _scopeFactory.CreateScope();
            this.customerDbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
        }

        /// <summary>
        /// Adds a customer transaction to the database.
        /// </summary>
        /// <param name="customerTransactions">The customer transaction to add.</param>
        public void Add(CustomerTransactions customerTransactions)
        {
            this.customerDbContext.Add<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a customer transaction from the database.
        /// </summary>
        /// <param name="customerTransactions">The customer transaction to remove.</param>
        public void Remove(CustomerTransactions customerTransactions)
        {
            this.customerDbContext.Remove<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();
        }

        /// <summary>
        /// Updates a customer transaction in the database.
        /// </summary>
        /// <param name="customerTransactions">The customer transaction to update.</param>
        public void Update(CustomerTransactions customerTransactions)
        {
            this.customerDbContext.Update<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();
        }

        /// <summary>
        /// Retrieves all customer transactions from the database.
        /// </summary>
        /// <returns>A list of customer transactions.</returns>
        public List<CustomerTransactions> Read()
        {
            return this.customerDbContext.CustomerTransactions.ToList<CustomerTransactions>();
        }
    }
}

