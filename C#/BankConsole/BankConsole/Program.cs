using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create dictionary mapping User objects to usernames
            Dictionary<string, User> userDict = new Dictionary<string, User>();
            // Store current working profile while logged in
            User OpenProfile = null;
            Boolean IsLoggedIn = false;
            Boolean LoopMain = true;
            // Run Main program loop
            while (LoopMain == true)
            {
                // Provide menu options when logged out
                while (IsLoggedIn == false)
                {
                    Console.WriteLine("Welcome to LedgerApp!");
                    Console.WriteLine("Enter 1 to log in. Enter 2 to create an account");
                    string loginSelect = Console.ReadLine();
                    // Login
                    if (loginSelect == "1")
                    {
                        UserLogin.Login(userDict, ref IsLoggedIn, ref OpenProfile);
                    }
                    // Creat Account
                    if (loginSelect == "2")
                    {
                        UserLogin.CreateAccount(userDict);
                        Console.WriteLine();
                    }
                }
                // Provide menu options when logged in
                while (IsLoggedIn == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome!");
                    Console.WriteLine("To make a deposit, enter 1.");
                    Console.WriteLine("To make a withdrawal, enter 2.");
                    Console.WriteLine("To check your account balance, enter 3.");
                    Console.WriteLine("To view transaction history, enter 4.");
                    Console.WriteLine("To log out, enter 5.");
                    string taskSelect = Console.ReadLine();
                    Console.WriteLine();
                    // Make a deposit
                    if (taskSelect == "1")
                    {
                        AccountFxns.Deposit(OpenProfile);
                    }
                    // Make a withdrawal
                    else if (taskSelect == "2")
                    {
                        AccountFxns.Withdraw(OpenProfile);
                    }
                    // Check Balance
                    else if (taskSelect == "3")
                    {
                        AccountFxns.CheckBalance(OpenProfile);
                    }
                    // View Transaction History
                    else if (taskSelect == "4")
                    {
                        AccountFxns.TransactionHistory(OpenProfile);
                    }
                    // Log out
                    else if (taskSelect == "5")
                    {
                        UserLogin.Logout(ref IsLoggedIn, ref OpenProfile);
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
        }
    }
}
