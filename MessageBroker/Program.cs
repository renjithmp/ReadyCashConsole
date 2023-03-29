using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MessageBroker;
using CustomerCore.Model;
using MessageBroker.Consumers;
using LoanCore.Model;
using Microsoft.EntityFrameworkCore;
using CustomerCore.Actions;

var consumerConfig = new ConsumerConfig();
consumerConfig.BootstrapServers = "localhost:9092";
consumerConfig.GroupId = "1";

var producerConfig = new ProducerConfig();
producerConfig.BootstrapServers = "localhost:9092";

string loanDBConnectionstring = "Host=localhost; Database=loan; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;
string customerDBConnectionstring = "Host=localhost; Database=customer; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;
using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>

services.AddDbContext<LoanDbContext>(options =>options.UseNpgsql(loanDBConnectionstring))
.AddDbContext<CustomerDbContext>(options => options.UseNpgsql(customerDBConnectionstring))
.AddSingleton<ConsumerConfig>(consumerConfig)
.AddSingleton<CustomerTransactionsActions>()
   .AddSingleton<ProducerConfig>(producerConfig)    
    .AddSingleton<LoanTransactionConsumer>()
    .AddSingleton<ConsumerManager>()
    .AddHostedService<ReadyCashKafkaConsumer>()
).Build();

host.StartAsync();

//consumer.StartAsync();

host.WaitForShutdown();
//var producer = host.Services.GetService<ReadyCashKafkaProducer>();
//for (int i = 0; i < 10; i++)
//{
//    producer?.SendMessage();
//}
//Console.ReadLine();
