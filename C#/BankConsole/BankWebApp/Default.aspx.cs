using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankWebApp
{

    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            // Check to see if user exists
            if (((Dictionary<string, Account>)Session["accounts"]).ContainsKey(TextBoxUserID.Text))
            {
                // Check for correct login credentials
                if (((Dictionary<string, Account>)Session["accounts"])[TextBoxUserID.Text].Password == TextBoxPW.Text)
                {
                    // Store current user Account to Session variable
                    Session["CurrentUser"] = ((Dictionary<string, Account>)Session["accounts"])[TextBoxUserID.Text];
                    // 
                    FormsAuthentication.SetAuthCookie(TextBoxUserID.Text, true);
                    Response.Redirect("AccountHome.aspx");
                }
                else
                {
                    Response.Write("Invalid Username/Password.");
                }
            }
            else
            {
                Response.Write("No such username");
            }
        }
    }
}