using System;
using System.Text.Json;
using Confluent.Kafka;
using CustomerCore.Actions;
using CustomerCore.Model;

namespace MessageBroker.Consumers
{
	public class LoanTransactionConsumer
	{
		private CustomerTransactionsActions _customerTransactionsActions;

        public LoanTransactionConsumer(CustomerTransactionsActions customerTransactionsActions)
		{
			_customerTransactionsActions = customerTransactionsActions;
		}

	

		public void ReadKafkaMessage(string message)
		{
            CustomerTransactions customerTransaction = JsonSerializer.Deserialize<CustomerTransactions>(message);            
			_customerTransactionsActions.Add(customerTransaction);

		}
	}
}

