using System;
using System.Linq;
using CustomerCore.Model;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

namespace CustomerCore.Actions
{
	public class CustomerTransactionsTracker
	{
        private readonly IServiceScopeFactory _scopeFactory;

         CustomerDbContext customerDbContext;

        public CustomerTransactionsTracker(IServiceScopeFactory scopeFactory)
		{

            _scopeFactory = scopeFactory;
            var scope = _scopeFactory.CreateScope();
            this.customerDbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

        }

		public void Add(CustomerTransactions customerTransactions)
        {
            this.customerDbContext.Add<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();

        }
        public void Remove(CustomerTransactions customerTransactions)
        {
            this.customerDbContext.Remove<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();

        }
  
        public void Update(CustomerTransactions customerTransactions)
        {
            this.customerDbContext.Update<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();

        }
        public List<CustomerTransactions> Read()
        {
            return this.customerDbContext.CustomerTransactions.ToList<CustomerTransactions>();
        }

  
    }
}

