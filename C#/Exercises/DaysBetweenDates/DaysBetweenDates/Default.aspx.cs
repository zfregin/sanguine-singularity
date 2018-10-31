using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DaysBetweenDates
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okayButton_Click(object sender, EventArgs e)
        {
            DateTime date1 = calendar1.SelectedDate;
            DateTime date2 = calendar2.SelectedDate;
            TimeSpan daysElapsed;

            if (date2 > date1)
            {
                daysElapsed = date2.Subtract(date1);
            }
            else
            {
                daysElapsed = date1.Subtract(date2);
            }

            resultLabel.Text = daysElapsed.TotalDays.ToString();
        }
    }
}