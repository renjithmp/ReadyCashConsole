using System;
using CustomerCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CustomerCore.Model
{
/// <summary>
/// Represents the database context for the Customer entity.
/// </summary>
	public class CustomerDbContext:DbContext
	{
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerTransactions> CustomerTransactions { get; set; }
       

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomerDbContext"/> class.
            /// </summary>
            /// <param name="dbContextOptions">The options for configuring the database context.</param>
            public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            }
        }




    }



