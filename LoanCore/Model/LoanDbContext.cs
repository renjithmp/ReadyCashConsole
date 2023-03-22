using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace LoanCore.Model
{
	public class LoanDbContext:DbContext
	{
        
        public DbSet<Loan> Loans { get; set; }


        public LoanDbContext(DbContextOptions<LoanDbContext> dbContextOptions):base(dbContextOptions)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);


        }

    }

}

