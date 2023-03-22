using Confluent.Kafka;
using MessageBroker;

public class ReadyCashKafkaProducer 
{
    ProducerConfig _producerConfig;

    public ReadyCashKafkaProducer(ProducerConfig producerConfig)
    {
        _producerConfig = producerConfig;
    }

    /// <summary>
    /// Uses default producer config
    /// </summary>
    public ReadyCashKafkaProducer()
    {
        var producerConfig = new ProducerConfig() { BootstrapServers = "localhost:9092" };
        _producerConfig = producerConfig;
    }
    public async void SendMessage(int userId,int loanId)
    {
        string messageString = userId.ToString() + ";" + loanId.ToString();
        try
        {

            using (var producer = new ProducerBuilder<Null, string>(_producerConfig).Build())
            {
                var message = new Message<Null, string>();
                message.Value = messageString;
                var result = await producer.ProduceAsync(Topic.READYCASH, message);
            }

        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }


}