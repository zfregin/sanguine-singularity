using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostageCalculatorChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        private void performCalc()
        {
            // Check if values in textbox/radios
            if (!valuesExist()) return;
            // What is the volume of the package?
            float volume = 0;
            if (!tryGetVolume(out volume)) return;
            // What is the cost of the shipment?
            double cost = volume * getMultiplier();
            // Display info to user
            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship", cost);
        }

        private bool valuesExist()
        {
            // See if radio buttons selected
            if (!groundRadio.Checked
                && !airRadio.Checked
                && !nextDayRadio.Checked)
                return false;
            // See if textboxes are empty
            if (widthTextBox.Text.Trim().Length == 0
                | heightTextBox.Text.Trim().Length == 0)
                return false;

            return true;
        }

        private bool tryGetVolume(out float volume)
        {
            float width = 0;
            float height = 0;
            float length = 0;
            volume = 0;
            // If able to parse float value from textbox, return value, otherwise do nothing
            if (!float.TryParse(widthTextBox.Text.Trim(), out width)) return false;
            if (!float.TryParse(heightTextBox.Text.Trim(), out height)) return false;
            // If able to parse float value from textbox, return value, otherwise set length to 1
            if (!float.TryParse(lengthTextBox.Text.Trim(), out length)) length = 1;

            volume = width * height * length;
            return true;
        }

        private float getMultiplier()
        {
            if (groundRadio.Checked) return 0.15f;
            else if (airRadio.Checked) return 0.25f;
            else if (nextDayRadio.Checked) return 0.45f;
            else return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void handleChange(object sender, EventArgs e)
        {
            performCalc();
        }
    }
}