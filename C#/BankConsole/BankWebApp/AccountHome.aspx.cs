using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankWebApp
{
    public partial class AccountHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear Response Text on Postback
            if (IsPostBack)
            {
                LabelDeposit.Text = "";
                LabelWithdrawal.Text = "";
                LabelBalance.Text = "";
                LabelTransactions.Text = "";
            }
        }

        // Log out
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["CurrentUser"] = null;
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        // Check Balance
        protected void ButtonCheckBalance_Click(object sender, EventArgs e)
        {
            LabelBalance.Text = String.Format("Current Balance: {0:C}", ((Account)Session["CurrentUser"]).Balance);
        }

        // Make Deposit
        protected void ButtonDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                // Format input
                decimal deposit = Decimal.Parse(TextBoxDeposit.Text);
                // Validate positive input
                if (deposit < 0)
                {
                    LabelDeposit.Text = "Invalid deposit. Enter a number greater than zero.";
                }
                else
                {
                    // Create new Transaction object to store transaction data
                    Transaction depTxn = new Transaction
                    {
                        // Set initial balance, value, and transaction type
                        OriginalBalance = ((Account)Session["CurrentUser"]).Balance,
                        Withdrawal = false,
                        Amount = deposit
                    };
                    ((Account)Session["CurrentUser"]).Balance += depTxn.Amount;
                    // Set final balance
                    depTxn.EndBalance = ((Account)Session["CurrentUser"]).Balance;
                    depTxn.Date = DateTime.Now;
                    // Add transaction to User's history
                    ((Account)Session["CurrentUser"]).Transactions.Add(depTxn);
                    LabelDeposit.Text = "Deposit Successful";
                    //Console.WriteLine(String.Format("Account Balance: {0:C}", ((Dictionary<string, Account>)Session["accounts"])[(String)Session["CurrentUser"]].Balance));
                }
                
            }
            catch (FormatException)
            {
                LabelDeposit.Text = "Deposit failed. Please enter a valid number";
            }
        }

        protected void ButtonWithdrawal_Click(object sender, EventArgs e)
        {
            try
            {
                // Format Input
                decimal withdrawal = Decimal.Parse(TextBoxWithdrawal.Text);
                // Check for sufficient user balance
                if (((Account)Session["CurrentUser"]).Balance - withdrawal < 0)
                {
                    LabelWithdrawal.Text = "Insufficient funds";
                }
                // Validate positive input
                else if (withdrawal < 0)
                {
                    LabelWithdrawal.Text = "Invalid withdrawal. Enter a number greater than zero.";
                }
                else
                {
                    // Create new Transaction object to store transaction data
                    Transaction withdrawTxn = new Transaction
                    {
                        // Set initial balance value and transaction type
                        OriginalBalance = ((Account)Session["CurrentUser"]).Balance,
                        Withdrawal = true,
                        Amount = -withdrawal
                    };
                    ((Account)Session["CurrentUser"]).Balance += withdrawTxn.Amount;
                    // Set final balance
                    withdrawTxn.EndBalance = ((Account)Session["CurrentUser"]).Balance;
                    withdrawTxn.Date = DateTime.Now;
                    // Add transaction to User's history
                    ((Account)Session["CurrentUser"]).Transactions.Add(withdrawTxn);
                    LabelWithdrawal.Text = "Withdrawal Successful";
                }
            }
            catch (FormatException)
            {
                LabelWithdrawal.Text = "Withdrawal failed. Please enter a valid number";
            }
        }

        // View Transaction History
        protected void ButtonTransactions_Click(object sender, EventArgs e)
        {
            // Check for history
            if (((Account)Session["CurrentUser"]).Transactions.Count > 0)
            {
                // Iterate through list of user transactions to display
                for (int i = 0; i < ((Account)Session["CurrentUser"]).Transactions.Count; i++)
                {
                    LabelTransactions.Text += String.Format("{0}    {1} Amount: {2:C}   End Balance: {3:C} <br />", ((Account)Session["CurrentUser"]).Transactions[i].Date.ToString(), ((Account)Session["CurrentUser"]).Transactions[i].Withdrawal ? "Withdrawal" : "Deposit", ((Account)Session["CurrentUser"]).Transactions[i].Amount, ((Account)Session["CurrentUser"]).Transactions[i].EndBalance);

                }
            }
            else
            {
                LabelTransactions.Text = "You have no history to view.";
            }
        }
    }
}