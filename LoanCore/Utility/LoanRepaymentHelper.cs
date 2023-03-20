using System;
namespace LoanCore.Utility
{
    using System;
    using LoanCore.Model;

    class LoanRepaymentHelper
    {
        public List<LoanRepayment> loans;
        public void GenerateRepaymentSchedule(Loan loan)
        {
            double loanAmount = ((double)loan.Amount); // the loan amount
            double interestRate = ((double)loan.InterestRate); // the annual interest rate
            int loanTerm = loan.TermInMonths; // the loan term in months
            double monthlyInterestRate = interestRate / 12; // the monthly interest rate
            double monthlyPayment = CalculateMonthlyPayment(loanAmount, monthlyInterestRate, loanTerm); // the monthly payment amount
            

            Console.WriteLine("Loan Amount: ${0}", loanAmount);
            Console.WriteLine("Interest Rate: {0}%", interestRate * 100);
            Console.WriteLine("Loan Term: {0} months", loanTerm);
            Console.WriteLine("Monthly Payment: ${0:0.00}", monthlyPayment);
            Console.WriteLine();
            Console.WriteLine("Repayment Schedule:");
            Console.WriteLine("Month\tBeginning Balance\tPayment\tInterest\tPrincipal\tEnding Balance");

            double balance = loanAmount;

            for (int month = 1; month <= loanTerm; month++)
            {
                double interest = balance * monthlyInterestRate;
                double principal = monthlyPayment - interest;
                balance -= principal;

                Console.WriteLine("{0}\t${1:0.00}\t\t${2:0.00}\t${3:0.00}\t${4:0.00}\t${5:0.00}",
                    month, balance + principal, monthlyPayment, interest, principal, balance);
            }
        }

        static double CalculateMonthlyPayment(double loanAmount, double monthlyInterestRate, int loanTerm)
        {
            double numerator = loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, loanTerm);
            double denominator = Math.Pow(1 + monthlyInterestRate, loanTerm) - 1;
            return numerator / denominator;
        }
    }

}

