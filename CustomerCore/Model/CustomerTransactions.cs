using System;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace CustomerCore.Model
{
    /// <summary>
    /// Represents a customer transaction.
    /// </summary>
    public class CustomerTransactions
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer ID associated with the transaction.
        /// </summary>
        public int customerId { get; set; }

        /// <summary>
        /// Gets or sets the transaction ID.
        /// </summary>
        public int transactionId { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public string transactionType { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the transaction.
        /// </summary>
        public DateTime transactionTimestamp { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTransactions"/> class with the specified parameters.
        /// </summary>
        /// <param name="customerId">The customer ID associated with the transaction.</param>
        /// <param name="transactionId">The transaction ID.</param>
        /// <param name="transactionType">The type of the transaction.</param>
        /// <param name="transactionTimestamp">The timestamp of the transaction.</param>
        public CustomerTransactions(int customerId, int transactionId, string transactionType, DateTime transactionTimestamp)
        {
            this.customerId = customerId;
            this.transactionId = transactionId;
            this.transactionType = transactionType;
            this.transactionTimestamp = transactionTimestamp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTransactions"/> class with default values.
        /// </summary>
        public CustomerTransactions()
        {
            transactionType = "Default";
        }
    }
}

