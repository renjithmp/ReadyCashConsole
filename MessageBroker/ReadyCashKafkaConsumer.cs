using System;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace MessageBroker
{
	public class ReadyCashKafkaConsumer:Microsoft.Extensions.Hosting.BackgroundService
	{
       
        ConsumerConfig _consumerConfig;       
        public ReadyCashKafkaConsumer(ConsumerConfig consumerConfig)
        {       
            _consumerConfig = consumerConfig;
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
                        if (!string.IsNullOrEmpty(consumeResult))
                        {
                            Console.WriteLine(consumeResult);
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

