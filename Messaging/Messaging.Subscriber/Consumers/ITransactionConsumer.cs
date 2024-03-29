using System;
namespace Messaging.Subscriber.Consumers
{
	public interface ITransactionConsumer
	{
        public void ReadKafkaMessage(string message);

        public void ExecuteActions();

    }
}

