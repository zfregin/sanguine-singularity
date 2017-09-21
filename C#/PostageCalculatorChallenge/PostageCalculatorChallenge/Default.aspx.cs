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
        private float getDimensions()
        {
            float width = float.Parse(widthTextBox.Text);
            float height = float.Parse(heightTextBox.Text);
            //float length = float.TryParse(lengthTextBox.Text);
            if (lengthTextBox.Text == "")
            {
                return getVolume(width, height);
            }
            else
            {
                float length = float.Parse(lengthTextBox.Text);
                return getVolume(width, height, length);
            }

        }

        private float getVolume(float width, float height, float length = 1)
        {
            float volume = width * height * length;

            return volume;
        }

        private float getMultiplier()
        {
            if (groundRadio.Checked)
            {
                return getDimensions() * 0.15f;
            }
            else if (airRadio.Checked)
            {
                return getDimensions() * 0.25f;
            }
            else if (nextDayRadio.Checked)
            {
                return getDimensions() * 0.45f;
            }
            else return 0;
        }

        private void labelMessage()
        {
            if (((widthTextBox.Text == "") |
               (widthTextBox.Text == "0")) |
               ((heightTextBox.Text == "") |
               (heightTextBox.Text == "0")))
            {
                resultLabel.Text = "Please enter a nonzero width and height";
            } else
            resultLabel.Text = string.Format("Your parcel will cost {0:C} to ship", getMultiplier());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void groundRadio_CheckedChanged(object sender, EventArgs e)
        {
            labelMessage();
        }

        protected void airRadio_CheckedChanged(object sender, EventArgs e)
        {
            labelMessage();
        }

        protected void nextDayRadio_CheckedChanged(object sender, EventArgs e)
        {
            labelMessage();
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            labelMessage();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            labelMessage();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            labelMessage();
        }
    }
}