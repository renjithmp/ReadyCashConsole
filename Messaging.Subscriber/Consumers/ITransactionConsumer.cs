using System;
namespace MessagingSubscriber.Consumers
{
	public interface ITransactionConsumer
	{
        public void ReadKafkaMessage(string message);

        public void ExecuteActions();

    }
}

