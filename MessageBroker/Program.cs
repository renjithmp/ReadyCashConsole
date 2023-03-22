using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MessageBroker;

var consumerConfig = new ConsumerConfig();
consumerConfig.BootstrapServers = "localhost:9092";
consumerConfig.GroupId = "1";

var producerConfig = new ProducerConfig();
producerConfig.BootstrapServers = "localhost:9092";


using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>


    services.AddSingleton<ConsumerConfig>(consumerConfig).
    AddSingleton<ProducerConfig>(producerConfig)
    .AddSingleton<ReadyCashKafkaProducer>().
    AddHostedService<ReadyCashKafkaConsumer>()).Build();

host.StartAsync();
host.WaitForShutdown();
//var producer = host.Services.GetService<ReadyCashKafkaProducer>();
//for (int i = 0; i < 10; i++)
//{
//    producer?.SendMessage();
//}
//Console.ReadLine();
