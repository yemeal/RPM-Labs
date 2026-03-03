using SOLID_Fundamentals.Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Bank.Accounts
{
    public abstract class BaseAccount : IBankAccount, IInterestEarning
    {
        public decimal Balance { get; protected set; }
        public virtual void Deposit(decimal amount)
        { 
            Balance += amount;
        }
        public virtual decimal CalculateInterest() => Balance * 0.01m;
    }
}
