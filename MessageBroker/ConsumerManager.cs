using System;
using MessageBroker.Consumers;

namespace MessageBroker
{
	public class ConsumerManager
	{

		LoanTransactionConsumer _loanTransactionConsumer;
        public ConsumerManager(LoanTransactionConsumer loanTransactionConsumer)

        {
            _loanTransactionConsumer = loanTransactionConsumer;
        }

        public  void ConsumeMessage(string message)
		{
			_loanTransactionConsumer.ReadKafkaMessage(message);

		}
		
	}
}

