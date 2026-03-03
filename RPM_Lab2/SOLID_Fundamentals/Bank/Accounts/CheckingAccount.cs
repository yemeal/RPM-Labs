using SOLID_Fundamentals.Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Bank.Accounts
{
    public class CheckingAccount: BaseAccount, IWithdrawable
    {
        public decimal OverdraftLimit { get; } = 500m;
        public bool CanWithdraw { get; } = true;
        
        public void Withdraw(decimal amount)
        {
            if (Balance - amount < -OverdraftLimit)
            {
                throw new InvalidOperationException("Overdraft limit exceeded");
            }
            Balance -= amount;
        }
    }
}
