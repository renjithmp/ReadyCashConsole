using System.Diagnostics;


namespace Messaging.Publisher
{
    /// <summary>
    /// Represents a message producer that sends notifications.
    /// </summary>
    /// <typeparam name="T">The type of message to be sent.</typeparam>
    public class NotificationGenerator<T> 
    {
        /// <summary>
        /// Announces a message by sending it through the ReadyCashKafkaProducer.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        public void Announce(T message)
        {
            var readyCashKafkaProducer = new ReadyCashKafkaProducer<T>();       
            readyCashKafkaProducer.SendMessage(message);
        }

    }
}

