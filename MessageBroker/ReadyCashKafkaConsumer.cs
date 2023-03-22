using System;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Configuration;
using CustomerCore.Actions;
using CustomerCore.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageBroker
{
	public class ReadyCashKafkaConsumer:Microsoft.Extensions.Hosting.BackgroundService
	{
       
        ConsumerConfig _consumerConfig;
        CustomerTransactionsActions customerTransactionsActions;
        public ReadyCashKafkaConsumer(ConsumerConfig consumerConfig)
        {       
            _consumerConfig = consumerConfig;
            var dbContextOptions = new DbContextOptionsBuilder<CustomerDbContext>();
            dbContextOptions.UseNpgsql("Host=localhost; Database=customer; Username=webuser; Password=SocGen01*");
            


            customerTransactionsActions = new CustomerTransactionsActions(new CustomerCore.Model.CustomerDbContext(dbContextOptions.Options));
		}
        private async Task  StartConsumer(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build())
                    {
                        consumer.Subscribe(Topic.READYCASH);

                        var consumeResult = consumer.Consume().Message.Value;
                        Console.WriteLine("got some message");
                        Console.WriteLine(consumeResult.ToString());
                        if (!string.IsNullOrEmpty(consumeResult))
                        {
                            try
                            {
                                string userId = consumeResult.Substring(0, 1);
                                string loanId = consumeResult.Substring(2,  1);
                                var customerTransaction = new CustomerTransactions(Convert.ToInt32(userId), Convert.ToInt32(loanId), "loan", DateTime.Now);

                                customerTransactionsActions.Add(customerTransaction);
                            }
                            catch (Exception e) { Console.WriteLine(e.ToString()); }
                        }



                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() => StartConsumer(stoppingToken));
            return Task.CompletedTask;
        }
    }
}

