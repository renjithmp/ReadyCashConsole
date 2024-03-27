using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace LoanCore.Model
{
    /// <summary>
    /// Represents the database context for managing loans.
    /// </summary>
    public class LoanDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet of loans.
        /// </summary>
        public DbSet<Loan> Loans { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">The options for configuring the database context.</param>
        public LoanDbContext(DbContextOptions<LoanDbContext> dbContextOptions) : base(dbContextOptions)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
    }
}

