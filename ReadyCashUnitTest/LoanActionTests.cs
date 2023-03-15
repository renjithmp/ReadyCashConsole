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
		public LoanActionTests():base()
		{
			loanActions = new LoanActions(bankDbContext);
			customerActions = new CustomerActions(bankDbContext);
		}

		[TestMethod]
		public void TestAddLoan() {

			customerActions.Add(new Customer("renjith", "renjithmac@gmail.com", "90898", "renjithAdd"));
			Customer customer = customerActions.FindByName("renjith").First();
			Loan loan = new Loan(customer.Id, 10000, 10, 12);
			loanActions.Add(loan);

			Loan customerLoan = loanActions.FindByUserId(customer.Id).First();
			Assert.IsNotNull(customerLoan);

		}
	}
}

