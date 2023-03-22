using System;
namespace Base
{
	public interface ITransactionService
	{
		public void Execute(int userId, decimal amount, decimal interestRate, int termInMonths);
	}
}

