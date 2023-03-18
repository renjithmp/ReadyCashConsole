using System;
using LoanCore.Model;

namespace LoanCore.Actions
{
    public class LoanActions
    {
        readonly LoanDbContext bankDbContext;
        public LoanActions(LoanDbContext bankDbContext)
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
        public void RemoveByLoanId(int id)
        {
            var loans = this.bankDbContext.Loans.Where(loan => loan.Id.Equals(id)).ToList<Loan>();
            this.bankDbContext.Remove(loans.First());
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

