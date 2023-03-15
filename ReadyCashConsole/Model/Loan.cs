using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyCashConsole.Model
{
    public class Loan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermInMonths { get; set; }
        public decimal MonthlyPayment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        // Constructor
        public Loan(int userId, decimal amount, decimal interestRate, int termInMonths)
        {
            UserId = userId;
            Amount = amount;
            InterestRate = interestRate;
            TermInMonths = termInMonths;
            MonthlyPayment = CalculateMonthlyPayment();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

        // Method to calculate the monthly payment based on the loan amount, interest rate, and term in months
        private decimal CalculateMonthlyPayment()
        {
            decimal monthlyInterestRate = InterestRate / 1200m;
            decimal monthlyPayment = Amount * (monthlyInterestRate + (monthlyInterestRate / (decimal)(Math.Pow((double)(1 + monthlyInterestRate), TermInMonths) - 1)));
            return decimal.Round(monthlyPayment, 2);
        }
    }

}

