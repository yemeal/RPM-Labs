using SOLID_Fundamentals.Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Bank.Accounts
{
    public class FixedDepositAccount : BaseAccount, IWithdrawable
    {
        public DateTime MaturityDate { get; }
        public bool CanWithdraw => DateTime.Now >= MaturityDate;

        public FixedDepositAccount(DateTime maturityDate)
        {
            MaturityDate = maturityDate;
        }

        public void Withdraw(decimal amount) 
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            if (!CanWithdraw)
            {
                throw new InvalidOperationException("Cannot withdraw before maturity date");
            }

            Balance -= amount;
        }

        public override decimal CalculateInterest()
        {
            return Balance * 0.05m;
        }
    }
}
