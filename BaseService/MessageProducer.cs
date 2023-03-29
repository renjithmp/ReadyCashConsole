namespace Base;
public class MessageProducer<T> 
{
 
    public void Notify(T message)
    {
        var readyCashKafkaProducer = new ReadyCashKafkaProducer<T>();       
        readyCashKafkaProducer.SendMessage(message);
    }
}

