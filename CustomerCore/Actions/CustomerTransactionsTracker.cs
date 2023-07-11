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

        private void SetDbContext()
        {
            //using (
            var scope = _scopeFactory.CreateScope();
            //)
            //{
                this.customerDbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

                //this.customerDbContext = customerDbContext;
            //}
            //return customerDbContext;
        }
        public CustomerTransactionsTracker(IServiceScopeFactory scopeFactory)
		{

            _scopeFactory = scopeFactory;
            var scope = _scopeFactory.CreateScope();
            this.customerDbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

        }

		public void Add(CustomerTransactions customerTransactions)
        {
           // SetDbContext();
            this.customerDbContext.Add<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();

        }
        public void Remove(CustomerTransactions customerTransactions)
        {
           // SetDbContext();
            this.customerDbContext.Remove<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();

        }
  
        public void Update(CustomerTransactions customerTransactions)
        {
          //  SetDbContext();
            this.customerDbContext.Update<CustomerTransactions>(customerTransactions);
            this.customerDbContext.SaveChanges();

        }
        public List<CustomerTransactions> Read()
        {
           // SetDbContext();
            return this.customerDbContext.CustomerTransactions.ToList<CustomerTransactions>();
        }

  
    }
}

