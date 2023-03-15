using System;
using Bank.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ReadyCashConsole.Model
{
	public class BankDbContext:DbContext
	{
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }


        public BankDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
          
        }
       
	}

}

