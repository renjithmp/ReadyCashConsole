using System;
namespace KafkaMessage.Messages
{
    /// <summary>
    /// Represents a loan transaction message.
    /// </summary>
    public class LoanTransactionMessage
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int customerId { get; set; }

        /// <summary>
        /// Gets or sets the transaction ID.
        /// </summary>
        public int transactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction type.
        /// </summary>
        public string transactionType { get; set; }

        /// <summary>
        /// Gets or sets the transaction timestamp.
        /// </summary>
        public DateTime transactionTimestamp { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanTransactionMessage"/> class.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <param name="transactionId">The transaction ID.</param>
        /// <param name="transactionType">The transaction type.</param>
        /// <param name="transactionTimestamp">The transaction timestamp.</param>
        public LoanTransactionMessage(int customerId, int transactionId, string transactionType, DateTime transactionTimestamp)
        {
            this.customerId = customerId;
            this.transactionId = transactionId;
            this.transactionType = transactionType;
            this.transactionTimestamp = transactionTimestamp;
        }
    }
}

