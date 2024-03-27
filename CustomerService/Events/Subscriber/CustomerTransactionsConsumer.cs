using System;
using System.Text.Json;
using KafkaMessage.Messages;
using CustomerCore.Actions;
using CustomerCore.Model;

namespace MessagingSubscriber.Consumers
{
    /// <summary>
    /// Represents a consumer for customer transactions.
    /// </summary>
    public class CustomerTransactionsConsumer : ITransactionConsumer
    {
        CustomerTransactionsTracker _customerTransactionsTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTransactionsConsumer"/> class.
        /// </summary>
        /// <param name="customerTransactionsTracker">The customer transactions tracker.</param>
        public CustomerTransactionsConsumer(CustomerTransactionsTracker customerTransactionsTracker)
        {
            _customerTransactionsTracker = customerTransactionsTracker;
        }

        /// <summary>
        /// Executes the actions for processing customer transactions.
        /// </summary>
        public void ExecuteActions()
        {
            // throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a Kafka message and processes it as a customer transaction.
        /// </summary>
        /// <param name="message">The Kafka message.</param>
        public void ReadKafkaMessage(string message)
        {
            // There could be many different types of messages a Customer Transaction Consumer reads.
            // LoanTransactionMessage is one among them.
            LoanTransactionMessage customerTransaction = JsonSerializer.Deserialize<LoanTransactionMessage>(message);
            
            // todo: use automapper
            
            CustomerTransactions customerTransactions = new CustomerTransactions()
            {
                customerId = customerTransaction.customerId,
                transactionId = customerTransaction.transactionId,
                transactionTimestamp = customerTransaction.transactionTimestamp,
                transactionType = customerTransaction.transactionType
            };

            _customerTransactionsTracker.Add(customerTransactions);
        }
    }
}

