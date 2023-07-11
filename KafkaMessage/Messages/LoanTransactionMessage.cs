using System;
namespace KafkaMessage.Messages
{
    public class LoanTransactionMessage
    {
       

        public int customerId { get; set; }
        public int transactionId { get; set; }
        public string transactionType { get; set; }
        public DateTime transactionTimestamp { get; set; }



        public LoanTransactionMessage(int customerId, int transactionId, string transactionType, DateTime transactionTimestamp)
        {
            this.customerId = customerId;
            this.transactionId = transactionId;
            this.transactionType = transactionType;
            this.transactionTimestamp = transactionTimestamp;

        }
    
    }
	
}

