using System;
using Bank.Model;
using ReadyCashConsole.Model;

namespace ReadyCashConsole.Actions
{
    public class LoanActions
    {
        readonly BankDbContext bankDbContext;
        public LoanActions(BankDbContext bankDbContext)
        {

            this.bankDbContext = bankDbContext;

        }

        public void Add(Loan loan)
        {
            this.bankDbContext.Add<Loan>(loan);
            this.bankDbContext.SaveChanges();

        }
        public void Remove(Loan loan)
        {
            this.bankDbContext.Remove<Loan>(loan);
            this.bankDbContext.SaveChanges();

        }
        public void RemoveByLoanId(int loanId)
        {
            var loans = this.bankDbContext.Loans.Where(loan => loan.LoanId.Equals(loanId)).ToList<Loan>();
            this.bankDbContext.Remove(loans);
            this.bankDbContext.SaveChanges();

        }
        public void Update(Loan loan)
        {
            this.bankDbContext.Update<Loan>(loan);
            this.bankDbContext.SaveChanges();

        }
        public List<Loan> Read()
        {
            return this.bankDbContext.Loans.ToList<Loan>();
        }

        public List<Loan> FindByUserId(int userId)
        {
            return this.bankDbContext.Loans.Where(loan => loan.UserId.Equals(userId)).ToList<Loan>();
        }
    }
}

