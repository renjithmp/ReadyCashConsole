using System;
using LoanCore.Model;
using Messaging.Publisher;
using Messaging.Model.Messages;
namespace LoanCore.Actions
{
/// <summary>
/// Represents a class that performs various actions related to loans.
/// </summary>
public class LoanActions
{
    readonly LoanDbContext bankDbContext;
        NotificationGenerator<LoanTransactionMessage> _notificationGenerator;
    // Add the missing using directive

public void SetNotificationGenerator(NotificationGenerator<LoanTransactionMessage> notificationGenerator)
{
    _notificationGenerator = notificationGenerator;
}
    /// <summary>
    /// Initializes a new instance of the <see cref="LoanActions"/> class.
    /// </summary>
    /// <param name="bankDbContext">The loan database context.</param>
    public LoanActions(LoanDbContext bankDbContext)
    {
        this.bankDbContext = bankDbContext;
    }

    /// <summary>
    /// Adds a new loan to the database.
    /// </summary>
    /// <param name="loan">The loan to be added.</param>
    public void Add(Loan loan)
    {
        this.bankDbContext.Add<Loan>(loan);
        this.bankDbContext.SaveChanges();
        LoanTransactionMessage customerTransactions = new LoanTransactionMessage(loan.UserId , loan.Id, "loan", DateTime.Now);
			_notificationGenerator.Announce(customerTransactions);
    }

    /// <summary>
    /// Removes a loan from the database.
    /// </summary>
    /// <param name="loan">The loan to be removed.</param>
    public void Remove(Loan loan)
    {
        this.bankDbContext.Remove<Loan>(loan);
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Removes a loan from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the loan to be removed.</param>
    public void RemoveByLoanId(int id)
    {
        var loans = this.bankDbContext.Loans.Where(loan => loan.Id.Equals(id)).ToList<Loan>();
        this.bankDbContext.Remove(loans.First());
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Updates a loan in the database.
    /// </summary>
    /// <param name="loan">The loan to be updated.</param>
    public void Update(Loan loan)
    {
        this.bankDbContext.Update<Loan>(loan);
        this.bankDbContext.SaveChanges();
    }

    /// <summary>
    /// Retrieves all loans from the database.
    /// </summary>
    /// <returns>A list of all loans.</returns>
    public List<Loan> Read()
    {
        return this.bankDbContext.Loans.ToList<Loan>();
    }

    /// <summary>
    /// Retrieves loans associated with a specific user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A list of loans associated with the user.</returns>
    public List<Loan> FindByUserId(int userId)
    {
        return this.bankDbContext.Loans.Where(loan => loan.UserId.Equals(userId)).ToList<Loan>();
    }
}
}
