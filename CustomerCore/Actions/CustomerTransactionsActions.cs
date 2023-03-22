using System;
using System.Linq;
using CustomerCore.Model;


namespace CustomerCore.Actions

{
	public class CustomerTransactionsActions
	{

        readonly CustomerDbContext customerDbContext;
        public CustomerTransactionsActions(CustomerDbContext customerDbContext)
		{

           this.customerDbContext = customerDbContext;


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

