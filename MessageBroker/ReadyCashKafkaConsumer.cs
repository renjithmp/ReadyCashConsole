using System;
using Confluent.Kafka.SyncOverAsync;

using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Configuration;
using CustomerCore.Actions;
using CustomerCore.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MessageBroker
{
	public class ReadyCashKafkaConsumer:Microsoft.Extensions.Hosting.BackgroundService
	{
        
        public ConsumerManager _consumerManager;
       

        ConsumerConfig _consumerConfig;
        CustomerTransactionsActions customerTransactionsActions;
        public ReadyCashKafkaConsumer(ConsumerConfig consumerConfig,ConsumerManager consumerManager)
        {       
            _consumerConfig = consumerConfig;
            _consumerManager = consumerManager;
          
		}
        private async Task  StartConsumer(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var consumer = new ConsumerBuilder<Ignore,string>(_consumerConfig).Build() )
                    {
                        consumer.Subscribe(Topic.READYCASH);

                        var consumeResult = consumer.Consume().Message.Value;
                        Console.WriteLine("got some message");
                        Console.WriteLine(consumeResult?.ToString());
                        if (consumeResult!=null)
                        {
                            try
                            {
                                _consumerManager.ConsumeMessage(consumeResult); 
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

