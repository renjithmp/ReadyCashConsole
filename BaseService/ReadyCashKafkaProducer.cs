using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

/// <summary>
/// Represents a Kafka producer for sending messages.
/// </summary>
/// <typeparam name="T">The type of the message to be sent.</typeparam>
namespace MessagingPublisher
{
    public class ReadyCashKafkaProducer<T>
    {
        readonly ProducerConfig _producerConfig;

        /// <summary>
        /// Uses default producer config
        /// </summary>
        public ReadyCashKafkaProducer()
        {
            var producerConfig = new ProducerConfig() { BootstrapServers = "localhost:9092" };
            _producerConfig = producerConfig;
        }
        /// <summary>
        /// Sends a message asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the notification message.</typeparam>
        /// <param name="notificationMessage">The notification message to send.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SendMessage(T notificationMessage)
        {
            try
            {
                using (var producer = new ProducerBuilder<Null, string>(_producerConfig).Build())
                {
                    var message = new Message<Null, string>();
                    message.Value = Newtonsoft.Json.JsonConvert.SerializeObject(notificationMessage);
                    var result = await producer.ProduceAsync("ready-cash-loan", message);
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}