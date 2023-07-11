using System;
using Base;
//using CustomerCore.Model;
using KafkaMessage.Messages;
using LoanCore.Actions;
using LoanCore.Model;

namespace LoanService.Domain

{
	public class LoanAccountService
	{
		LoanActions _loanActions;
		MessageProducer<LoanTransactionMessage> _messageProducer;
	
		public LoanAccountService(LoanActions loanActions,MessageProducer<LoanTransactionMessage> messageProducer
			)
		{
			_loanActions = loanActions;
			_messageProducer = messageProducer;
			
		}
        public void Execute(int userId, decimal amount, decimal interestRate, int termInMonths)
        {
			int loanId = CreateLoan(userId, amount, interestRate, termInMonths);
            LoanTransactionMessage customerTransactions = new LoanTransactionMessage(userId,loanId,"loan",DateTime.Now);
			_messageProducer.Notify(customerTransactions);

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

