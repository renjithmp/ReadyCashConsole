using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MessageBroker;

var consumerConfig = new ConsumerConfig();
consumerConfig.BootstrapServers = "localhost:9092";
consumerConfig.GroupId = "1";

using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
{
    
    services.AddSingleton<ConsumerConfig>(consumerConfig);
    services.AddHostedService<ReadyCashKafkaConsumer>();
}).Build();

host.StartAsync();
Console.ReadLine();
