using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCore.Model
{
	public class CustomerTransactions
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int customerId { get; set; }
        public int transactionId { get; set; }
        public string transactionType { get; set; }
        public DateTime transactionTimestamp { get; set; }


        public CustomerTransactions(int customerId,int transactionId,string transactionType,DateTime transactionTimestamp)
		{
            this.customerId = customerId;
            this.transactionId = transactionId;
            this.transactionType = transactionType;
            this.transactionTimestamp = transactionTimestamp;

        }
	}
}

