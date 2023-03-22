using System;
using Base;
using LoanCore.Actions;
using LoanCore.Model;

namespace LoanService.Domain

{
	public class LoanAccountService:BaseService
	{
		LoanActions _loanActions;
		public LoanAccountService(LoanActions loanActions)
		{
			_loanActions = loanActions;
		}
        public override void Execute(int userId, decimal amount, decimal interestRate, int termInMonths)
        {
			int loanId=CreateLoan(userId, amount, interestRate, termInMonths);
			base.Notify(userId,loanId);
            base.Execute( userId,  amount,  interestRate,  termInMonths);


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

