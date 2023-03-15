using System;
using Microsoft.EntityFrameworkCore;
using ReadyCashConsole.Actions;
using ReadyCashConsole.Model;

namespace ReadyCashUnitTest
{
	public class BaseTest
	{
       protected BankDbContext bankDbContext;
        public BaseTest()
		{
            DbContextOptionsBuilder dbContextOptions = new DbContextOptionsBuilder();
            dbContextOptions.UseInMemoryDatabase(databaseName: "inMemoryReadyCashDb");
            bankDbContext = new BankDbContext(dbContextOptions.Options);
           
        }
	}
}

