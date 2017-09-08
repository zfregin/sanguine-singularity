using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCalc
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            float val1 = float.Parse(val1TextBox.Text);
            float val2 = float.Parse(val2TextBox.Text);

            float sum = val1 + val2;
            resultLabel.Text = sum.ToString();
        }

        protected void subtractButton_Click(object sender, EventArgs e)
        {
            float val1 = float.Parse(val1TextBox.Text);
            float val2 = float.Parse(val2TextBox.Text);

            float difference = val1 - val2;
            resultLabel.Text = difference.ToString();
        }

        protected void multiplyButton_Click(object sender, EventArgs e)
        {
            float val1 = float.Parse(val1TextBox.Text);
            float val2 = float.Parse(val2TextBox.Text);

            float product = val1 * val2;
            resultLabel.Text = product.ToString();
        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            float val1 = float.Parse(val1TextBox.Text);
            float val2 = float.Parse(val2TextBox.Text);

            float quotient = val1 / val2;
            resultLabel.Text = quotient.ToString();
        }
    }
}