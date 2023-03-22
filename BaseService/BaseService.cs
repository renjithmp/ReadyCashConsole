namespace Base;
public class BaseService : ITransactionService
{
    public virtual void Execute(int userId, decimal amount, decimal interestRate, int termInMonths)
    {
        
    }

    public void Notify(int userId, int loanId)
    {
        var readyCashKafkaProducer = new ReadyCashKafkaProducer();
        readyCashKafkaProducer.SendMessage(userId,loanId);
    }
}

