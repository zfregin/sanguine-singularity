using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    static class AccountFxns
    {
        public static void Deposit(User _user)
        {
            try
            {
                
                // Take user deposit input
                Console.WriteLine("Enter the amount to deposit:");
                // Format input
                decimal deposit = Decimal.Parse(Console.ReadLine());
                // Validate positive input
                if (deposit < 0)
                {
                    Console.WriteLine("Invalid deposit. Enter a number greater than zero.");
                }
                else
                {
                    // Create new Transaction object to store transaction data
                    Transaction depTxn = new Transaction
                    {
                        // Set initial balance, value, and transaction type
                        OriginalBalance = _user.Balance,
                        Withdrawal = false,
                        Amount = deposit
                    };
                    _user.Balance += depTxn.Amount;
                    // Set final balance
                    depTxn.EndBalance = _user.Balance;
                    depTxn.Date = DateTime.Now;
                    // Add transaction to User's history
                    _user.Transactions.Add(depTxn);
                    Console.WriteLine(String.Format("Account Balance: {0:C}", _user.Balance));
                }
                
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Deposit failed. Please enter a valid number");
            }
        }

        public static void Withdraw(User _user)
        {
            
            
            try
            {
                // Take user withdrawal input
                Console.WriteLine("Enter the amount to withdraw:");
                // Format Input
                decimal withdrawal = Decimal.Parse(Console.ReadLine());
                // Check for sufficient user balance
                if (_user.Balance - withdrawal < 0)
                {
                    Console.WriteLine("Insufficient funds");
                }
                // Validate positive input
                else if (withdrawal < 0)
                {
                    Console.WriteLine("Invalid withdrawal. Enter a number greater than zero.");
                }
                else
                {
                    // Create new Transaction object to store transaction data
                    Transaction withdrawTxn = new Transaction
                    {
                        // Set initial balance value and transaction type
                        OriginalBalance = _user.Balance,
                        Withdrawal = true,
                        Amount = -withdrawal
                    };
                    _user.Balance += withdrawTxn.Amount;
                    // Set final balance
                    withdrawTxn.EndBalance = _user.Balance;
                    withdrawTxn.Date = DateTime.Now;
                    // Add transaction to User's history
                    _user.Transactions.Add(withdrawTxn);
                    Console.WriteLine(String.Format("Account Balance: {0:C}", _user.Balance));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Withdrawal failed. Please enter a valid number");
            }

            
            
        }

        public static void CheckBalance(User _user)
        {
            decimal currentBalance = _user.Balance;
            Console.WriteLine(String.Format("Current Balance: {0:C}", currentBalance));
        }

        public static void TransactionHistory(User _user)
        {
            // Check for history
            if (_user.Transactions.Count > 0)
            {
                // Iterate through list of user transactions to display
                for (int i = 0; i < _user.Transactions.Count; i++)
                {
                    Console.WriteLine(String.Format("{0}    {1} Amount: {2:C}   End Balance: {3:C}",_user.Transactions[i].Date.ToString(), _user.Transactions[i].Withdrawal ? "Withdrawal" : "Deposit", _user.Transactions[i].Amount, _user.Transactions[i].EndBalance));
                }
            }
            else
            {
                Console.WriteLine("You have no history to view.");
            }
        }
    }
}
