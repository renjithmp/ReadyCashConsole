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
            DbContextOptionsBuilder dbContextOptions = new DbContextOptionsBuilder();
            dbContextOptions.UseInMemoryDatabase(databaseName: "inMemoryReadyCashDb");
            loanDbContext = new LoanDbContext(dbContextOptions.Options);
            customerDbContext = new CustomerDbContext(dbContextOptions.Options);

        }
    }
}

