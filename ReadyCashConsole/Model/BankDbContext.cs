using System;
using Microsoft.EntityFrameworkCore;

namespace ReadyCashConsole.Model
{
	public class BankDbContext:DbContext
	{
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=readycash; Username=webuser; Password=SocGen01*");
            base.OnConfiguring(optionsBuilder);
        }
       
	}
}

