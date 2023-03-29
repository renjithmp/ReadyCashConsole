using System;
using Base;
using CustomerCore.Model;
using LoanCore.Actions;
using LoanCore.Model;

namespace LoanService.Domain

{
	public class LoanAccountService
	{
		LoanActions _loanActions;
		public LoanAccountService(LoanActions loanActions)
		{
			_loanActions = loanActions;
		}
        public void Execute(int userId, decimal amount, decimal interestRate, int termInMonths)
        {
			int loanId=CreateLoan(userId, amount, interestRate, termInMonths);
			MessageProducer<CustomerTransactions> producer = new MessageProducer<CustomerTransactions>();
			CustomerTransactions customerTransactions = new CustomerTransactions();
			customerTransactions.customerId = userId;
			customerTransactions.transactionId = loanId;
			customerTransactions.transactionType = "loan";
			customerTransactions.transactionTimestamp = DateTime.Now;

			producer.Notify(customerTransactions);



        }
        public int CreateLoan(int userId, decimal amount, decimal interestRate, int termInMonths)
		{

			Loan loan = new Loan(userId, amount, interestRate, termInMonths);
			try
			{
				_loanActions.Add(loan);
			}
			catch (Exception e)
			{
			}
			return loan.Id;

		}

    }
}

