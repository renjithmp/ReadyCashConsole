using Confluent.Kafka;
//using CustomerCore.Actions;
using Messaging.Subscriber.Consumers;

namespace Messaging.Subscriber
{
    public class ConsumerSettings
    {
        public ConsumerConfig _consumerConfig;

        public ITransactionConsumer customerTransactionsActions;

        public ConsumerSettings(ITransactionConsumer transactionConsumer)
        {
            _consumerConfig= new ConsumerConfig();
            _consumerConfig.BootstrapServers = "localhost:9092";
            _consumerConfig.GroupId = "1";
            customerTransactionsActions = transactionConsumer;

        }
    }
}