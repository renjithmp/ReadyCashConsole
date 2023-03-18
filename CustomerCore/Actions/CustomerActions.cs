using System;
using System.Linq;
using CustomerCore.Model;


namespace CustomerCore.Actions

{
	public class CustomerActions
	{

        readonly CustomerDbContext bankDbContext;
        public CustomerActions(CustomerDbContext bankDbContext)
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
        public void RemoveByName(string name)
        {
            var customers = this.bankDbContext.Customers.Where(customer=> customer.Name.Equals(name)).ToList<Customer>();
            this.bankDbContext.Remove(customers);
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

        public List<Customer> FindByName(string name)
        {
            return this.bankDbContext.Customers.Where(cust => cust.Name.Equals(name)).ToList<Customer>();
        }
    }
}

