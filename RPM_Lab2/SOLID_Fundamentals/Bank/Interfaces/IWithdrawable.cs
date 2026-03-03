using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Bank.Interfaces
{
    public interface IWithdrawable
    {
        bool CanWithdraw { get; }
        void Withdraw(decimal amount);
    }
}
