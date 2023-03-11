using System;
using System.Linq;
using Bank.Model;
using ReadyCashConsole.Model;

namespace ReadyCashConsole
{
	public class CustomerActions
	{

        readonly BankDbContext bankDbContext;
        public CustomerActions(BankDbContext bankDbContext)
		{

            this.bankDbContext = bankDbContext;


		}

		public void Add(Customer customer)
        {
            this.bankDbContext.Add<Customer>(customer);
            this.bankDbContext.SaveChanges();

        }
        public void Remove(Customer customer)
        {
            this.bankDbContext.Remove<Customer>(customer);
            this.bankDbContext.SaveChanges();

        }
        public void Update(Customer customer)
        {
            this.bankDbContext.Update<Customer>(customer);
            this.bankDbContext.SaveChanges();

        }
        public List<Customer> Read()
        {
            return this.bankDbContext.Customers.ToList<Customer>();
        }

    }
}

