using System;
using Microsoft.EntityFrameworkCore;
using LoanCore.Actions;
using LoanCore.Model;
using CustomerCore;
using CustomerCore.Model;
namespace ReadyCashUnitTest
{
	public class BaseTest
	{
       protected CustomerDbContext customerDbContext;
        protected LoanDbContext loanDbContext;
        public BaseTest()
		{
            DbContextOptionsBuilder<LoanDbContext> loandbContextOptions = new DbContextOptionsBuilder<LoanDbContext>();
            DbContextOptionsBuilder<CustomerDbContext> customerdbContextOptions = new DbContextOptionsBuilder<CustomerDbContext>();
            loandbContextOptions.UseInMemoryDatabase(databaseName: "inMemoryCustomerDb");
            customerdbContextOptions.UseInMemoryDatabase(databaseName: "inMemoryLoanDb");
            loanDbContext = new LoanDbContext(loandbContextOptions.Options);
            customerDbContext = new CustomerDbContext(customerdbContextOptions.Options);

        }
    }
}

