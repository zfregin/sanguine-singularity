using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public User()
        {
            Transactions = new List<Transaction>();
            Balance = 0;
        }
    }
}
