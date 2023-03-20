using System;
using System.Security.Principal;

namespace LoanCore.Model
{
	public class LoanRepayment
    {

        public int month { get; set; }
        public double balanceAndPrinciple { get; set; }
        public double monthlyPayment { get; set; }
        public double interest { get; set; }
        public double principle { get; set; }
        public double balance { get; set; }
        public LoanRepayment()
        {



           }
    }
}

