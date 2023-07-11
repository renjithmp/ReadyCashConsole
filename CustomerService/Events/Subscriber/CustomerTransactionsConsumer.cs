using System;
using System.Text.Json;
using KafkaMessage.Messages;
using CustomerCore.Actions;
using CustomerCore.Model;

namespace MessagingSubscriber.Consumers
{
	public class CustomerTransactionsConsumer:ITransactionConsumer
	{
        CustomerTransactionsTracker _customerTransactionsTracker;
		public CustomerTransactionsConsumer(CustomerTransactionsTracker customerTransactionsTracker )
		{
            _customerTransactionsTracker = customerTransactionsTracker;
		}

        public void ExecuteActions()
        {
           // throw new NotImplementedException();
        }

        public void ReadKafkaMessage(string message)
        {
            //There could be many different types of message a Customer Transaction Consumer reads
            //LoanTransactionMessage is one among them
            LoanTransactionMessage customerTransaction = JsonSerializer.Deserialize<LoanTransactionMessage>(message);
            //ExecuteActions();
            //todo use automapper 
            CustomerTransactions customerTransactions = new CustomerTransactions()
            { customerId = customerTransaction.customerId,
                transactionId = customerTransaction.transactionId,
                transactionTimestamp = customerTransaction.transactionTimestamp,
                transactionType = customerTransaction.transactionType };

            _customerTransactionsTracker.Add(customerTransactions);

        }
    }
}

