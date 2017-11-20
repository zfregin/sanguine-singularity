using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpicSpiesChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Initialize previous end date to today's date
                previousEndCal.SelectedDate = DateTime.Now.Date;
                // Initialize start date 14 days from todays date
                startCal.SelectedDate = DateTime.Now.Date.AddDays(14);
                // Initialize projected end date 21 days from todays date
                projectedEndCal.SelectedDate = DateTime.Now.Date.AddDays(21);
            }
            
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            // Check for error where start date is before previous end date
            if (startCal.SelectedDate < previousEndCal.SelectedDate)
            {
                resultLabel.Text = "Error: Please select a Start Date 14 days " +
                    "GREATER than the End Date of Previous Assignment";
            }
            // Check for error where start date is not 2 weeks from previous end date
            else if (startCal.SelectedDate.Subtract(previousEndCal.SelectedDate).Days <= 13)
            {
                resultLabel.Text = "Error: Must allow at least two weeks between previous " +
                    "assignment and new assignment";
                // Reset the Start Date to a date 2 weeks from previous end date
                startCal.SelectedDate = previousEndCal.SelectedDate.AddDays(14);
            }
            else
            {
                // Get length of assignment
                int projectSpan = projectedEndCal.SelectedDate.Subtract(startCal.SelectedDate).Days;
                // Spy budget is $500 per day
                float budget = 500 * projectSpan;
                // If assignment is greater than 21 days, add $1000
                if (projectSpan > 21)
                {
                    budget += 1000;
                }
                // Print approved assignment and budget
                resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is " +
                    "authorized. Budget total: <br />{2:C}", spyNameTextBox.Text, assignmentNameTextBox.Text, budget);
            }
        }
    }
}