using System;
using LoanCore.Actions;
using LoanCore.Model;

namespace LoanService.Domain

{
	/// <summary>
	/// Represents a service for managing loan accounts.
	/// </summary>
	public class LoanAccountService
	{
		LoanActions _loanActions;


		/// <summary>
		/// Initializes a new instance of the <see cref="LoanAccountService"/> class.
		/// </summary>
		/// <param name="loanActions">The loan actions repository.</param>
		/// <param name="notificationGenerator">The notification generator.</param>
		public LoanAccountService(LoanActions loanActions)
		{
			_loanActions = loanActions;

		}

		/// <summary>
		/// Executes a loan transaction for the specified user.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="amount">The loan amount.</param>
		/// <param name="interestRate">The loan interest rate.</param>
		/// <param name="termInMonths">The loan term in months.</param>
		public void Execute(int userId, decimal amount, decimal interestRate, int termInMonths)
		{
			int loanId = CreateLoan(userId, amount, interestRate, termInMonths);
			
		}

		/// <summary>
		/// Creates a new loan for the specified user.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="amount">The loan amount.</param>
		/// <param name="interestRate">The loan interest rate.</param>
		/// <param name="termInMonths">The loan term in months.</param>
		/// <returns>The ID of the created loan.</returns>
		public int CreateLoan(int userId, decimal amount, decimal interestRate, int termInMonths)
		{
			Loan loan = new Loan(userId, amount, interestRate, termInMonths);
			try
			{
				_loanActions.Add(loan);
			}
			catch (Exception e)
			{
				// Handle the exception
			}
			return loan.Id;
		}
	}
}

