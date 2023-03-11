using System;
using Bank.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ReadyCashConsole.Model
{
	public class BankDbContext:DbContext
	{
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql( ConfigurationManager.ConnectionStrings["localPgsql"].ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
       
	}
}

