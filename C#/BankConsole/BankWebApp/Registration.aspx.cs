using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankWebApp
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Check if username exists
            if (((Dictionary<string, Account>)Session["accounts"]).ContainsKey(TextBoxUsername.Text))
            {
                Response.Write("Username already exists. Please try again.");
            }
            // Create new user
            else
            {
                Account user1 = new Account() { Username = TextBoxUsername.Text, Password = TextboxPWConf.Text };
                ((Dictionary<string, Account>)Session["accounts"]).Add(TextBoxUsername.Text, user1);
                Response.Write("Account successfully created.");
            }
        }
    }
}