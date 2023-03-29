using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;


public class ReadyCashKafkaProducer<T>
{
    ProducerConfig _producerConfig;


    AvroSerializerConfig avroSerializerConfig = new AvroSerializerConfig
    {
        // optional Avro serializer properties:
        BufferBytes = 100
    };


    /// <summary>
    /// Uses default producer config
    /// </summary>
    public ReadyCashKafkaProducer()
    {
        var producerConfig = new ProducerConfig() { BootstrapServers = "localhost:9092" };
        _producerConfig = producerConfig;
    }
    public async void SendMessage(T notificationMessage)
    {
      //  string messageString = userId.ToString() + ";" + loanId.ToString();
        try
        {
            //using (var schemaRegistry = new CachedSchemaRegistryClient(avroSerializerConfig))
            using (var producer = new ProducerBuilder<Null, string>(_producerConfig).Build())
            {
                var message = new Message<Null, string>();
                message.Value = Newtonsoft.Json.JsonConvert.SerializeObject(notificationMessage);
                var result = await producer.ProduceAsync("ready-cash-loan", message);
            }

        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }


}