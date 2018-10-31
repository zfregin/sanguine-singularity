using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
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
