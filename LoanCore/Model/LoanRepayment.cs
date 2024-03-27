using System;
using System.Security.Principal;

namespace LoanCore.Model
{
    /// <summary>
    /// Represents a loan repayment.
    /// </summary>
    public class LoanRepayment
    {
        /// <summary>
        /// Gets or sets the month of the repayment.
        /// </summary>
        public int month { get; set; }

        /// <summary>
        /// Gets or sets the balance and principle amount for the repayment.
        /// </summary>
        public double balanceAndPrinciple { get; set; }

        /// <summary>
        /// Gets or sets the monthly payment amount for the repayment.
        /// </summary>
        public double monthlyPayment { get; set; }

        /// <summary>
        /// Gets or sets the interest amount for the repayment.
        /// </summary>
        public double interest { get; set; }

        /// <summary>
        /// Gets or sets the principle amount for the repayment.
        /// </summary>
        public double principle { get; set; }

        /// <summary>
        /// Gets or sets the remaining balance after the repayment.
        /// </summary>
        public double balance { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanRepayment"/> class.
        /// </summary>
        public LoanRepayment()
        {
        }
    }
}

