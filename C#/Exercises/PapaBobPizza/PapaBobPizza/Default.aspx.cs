using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobPizza
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            double total = 0.00;

            if (babyRadio.Checked)
            {
                total += 10.00;
            }
            else if (mamaRadio.Checked)
            {
                total += 13.00;
            }
            else
            {
                total += 16.00;
            }

            if (deepDishRadio.Checked)
            {
                total += 2.00;
            }

            if (pepperoniCheckBox.Checked)
            {
                total += 1.50;
            }

            if (onionsCheckBox.Checked)
            {
                total += 0.75;
            }

            if (greenPeppersCheckBox.Checked)
            {
                total += 0.50;
            }

            if (redPeppersCheckBox.Checked)
            {
                total += 0.75;
            }

            if (anchoviesCheckBox.Checked)
            {
                total += 2.00;
            }

            if (pepperoniCheckBox.Checked && 
                ((greenPeppersCheckBox.Checked && anchoviesCheckBox.Checked) ||
                (redPeppersCheckBox.Checked && onionsCheckBox.Checked)))
            {
                total -= 2.00;
            }

            totalLabel.Text = "$" + total.ToString();
        }
    }
}