using System;
using CustomerCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CustomerCore.Model
{
	public class CustomerDbContext:DbContext
	{
        public DbSet<Customer> Customers { get; set; }
       

        public CustomerDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
          
        }
       
	}

}

