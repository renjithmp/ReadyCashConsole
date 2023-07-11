using System;
using Confluent.Kafka;

namespace MessagingSubscriber
{
	public class KafkaConsumer: Microsoft.Extensions.Hosting.BackgroundService
    {
        public ConsumerSettings _consumerSettings;
		public KafkaConsumer(ConsumerSettings consumerSettings)
		{
            _consumerSettings = consumerSettings;
		}

        private async Task StartConsumer(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    ConsumerConfig consumerConfig = _consumerSettings._consumerConfig;
                    using (var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
                    {
                        consumer.Subscribe(Topic.READYCASH);

                        var consumeResult = consumer.Consume().Message.Value;
                        Console.WriteLine("got some message");
                        Console.WriteLine(consumeResult?.ToString());
                            if (consumeResult != null)
                        {
                            try
                            {
                                _consumerSettings.customerTransactionsActions.ReadKafkaMessage(consumeResult);
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

