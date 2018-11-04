using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankWebApp
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
            Balance = 0;
        }
    }

    class Transaction
    {
        public Boolean Withdrawal { get; set; }
        public Decimal Amount { get; set; }
        public decimal OriginalBalance { get; set; }
        public decimal EndBalance { get; set; }
        public DateTime Date { get; set; }

        public Transaction()
        {
        }
    }
}