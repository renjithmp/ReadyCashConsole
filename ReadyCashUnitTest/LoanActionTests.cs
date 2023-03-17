using System;
using Bank.Model;
using ReadyCashConsole.Actions;
using ReadyCashConsole.Model;

namespace ReadyCashUnitTest
{
    [TestClass]
    public class LoanActionTests:BaseTest
	{
		LoanActions loanActions;
		CustomerActions customerActions;
        Customer customer;
		public LoanActionTests():base()
		{
			loanActions = new LoanActions(bankDbContext);
			customerActions = new CustomerActions(bankDbContext);
            customerActions.Add(new Customer("renjith", "renjithmac@gmail.com", "90898", "renjithAdd"));
            customer = customerActions.FindByName("renjith").First();
        }

		[TestMethod]
		public void TestAddLoan() {

			
			Loan loan = new Loan(customer.Id, 10000, 10, 12);
			loanActions.Add(loan);

			Loan customerLoan = loanActions.FindByUserId(customer.Id).First();
			Assert.IsNotNull(customerLoan);

		}

        [TestMethod]
        public void TestRemoveLoan()
        {
          
            Loan loan = new Loan(customer.Id, 10000, 10, 12);
            loanActions.Add(loan);

            loanActions.Remove(loan);
            List<Loan> loans = loanActions.Read();
            if (loans.Count > 0 && loans.Find(ln => ln.Id == loan.Id) != null)
            {
                Assert.Fail();
            }


        }

        [TestMethod]
        public void TestRemoveByLoanId()
        {
       
            Loan loan = new Loan(customer.Id, 10000, 10, 12);
            loanActions.Add(loan);

            loanActions.RemoveByLoanId(loan.Id);
            List<Loan> loans = loanActions.Read();
            if (loans!=null && loans.Count > 0 && loans.Find(ln => ln.Id == loan.Id) != null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestUpdateLoan()
        {
           
            Loan loan = new Loan(customer.Id, 10000, 10, 12);
            loanActions.Add(loan);
            loan.Amount = 20000;
            loanActions.Update(loan);
            List<Loan> loans = loanActions.Read();
            Loan? loanFromDb = loans.Find(ln => ln.Id == loan.Id);
            if (loanFromDb == null || loanFromDb.Amount != 20000)
                Assert.Fail();


        }

        [TestMethod]
        public void TestLoanFindByUserId()
        {
            Loan loan = new Loan(customer.Id, 10000, 10, 12);
            loanActions.Add(loan);
           ;
            List<Loan> loans = loanActions.FindByUserId(customer.Id);
            Loan? loanFromDb = loans.Find(ln => ln.UserId == customer.Id);
            if (loanFromDb == null )
                Assert.Fail();
        }
    }
}

