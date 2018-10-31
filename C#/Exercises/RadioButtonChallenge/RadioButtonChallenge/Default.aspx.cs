using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RadioButtonChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okayButton_Click(object sender, EventArgs e)
        {
            if (pencilRadio.Checked)
            {
                prefLabel.Text = "You selected Pencil";
                resultImage.ImageUrl = "pencil.png";
            }
            else if (penRadio.Checked)
            {
                prefLabel.Text = "You selected Pen";
                resultImage.ImageUrl = "pen.png";
            }
            else if (phoneRadio.Checked)
            {
                prefLabel.Text = "You selected Phone";
                resultImage.ImageUrl = "phone.png";
            }
            else if (tabletRadio.Checked)
            {
                prefLabel.Text = "You selected Tablet";
                resultImage.ImageUrl = "tablet.png";
            }
            else
            {
                prefLabel.Text = "Please select an option";
            }
        }
    }
}