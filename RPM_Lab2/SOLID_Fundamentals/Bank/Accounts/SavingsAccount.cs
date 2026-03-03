using SOLID_Fundamentals.Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Bank.Accounts
{
    public class SavingsAccount: BaseAccount, IWithdrawable
    {
        public decimal MinimumBalance { get; } = 100m;
        public bool CanWithdraw { get; } = true;

        public void Withdraw(decimal amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                throw new InvalidOperationException("Cannot go below minimum balance");
            }
            Balance -= amount;
        }
    }
}
