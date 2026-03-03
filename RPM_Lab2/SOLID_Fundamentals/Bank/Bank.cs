using SOLID_Fundamentals.Bank.Interfaces;

namespace SOLID_Fundamentals.Bank
{
    public class Bank
    {
        public void ProcessWithdrawal(IWithdrawable account, decimal amount)
        {
            if (!account.CanWithdraw) 
            {
                throw new InvalidOperationException("Cannot withdraw from this account");
            }
            
            try
            {   
                account.Withdraw(amount);
                Console.WriteLine($"Successfully withdrew {amount}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Withdrawal failed: {ex.Message}");
            }
        }

        public void Transfer(IWithdrawable from, IBankAccount to, decimal amount)
        {
            if (!from.CanWithdraw)
            {
                throw new InvalidOperationException("Cannot withdraw from this account");
            }
            
            from.Withdraw(amount);
            to.Deposit(amount);
            
        }
    }
}
