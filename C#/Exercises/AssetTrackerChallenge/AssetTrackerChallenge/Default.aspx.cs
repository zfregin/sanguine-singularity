using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetTrackerChallenge
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] assetArray = new string[0];
                float[] electionArray = new float[0];
                float[] subterfugeArray = new float[0];
                ViewState.Add("Assets", assetArray);
                ViewState.Add("Rigged Elections", electionArray);
                ViewState.Add("Acts of Subterfuge", subterfugeArray);
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {

            string[] assetArray = (string[])ViewState["Assets"];
            Array.Resize(ref assetArray, assetArray.Length + 1);

            float[] electionArray = (float[])ViewState["Rigged Elections"];
            Array.Resize(ref electionArray, electionArray.Length + 1);

            float[] subterfugeArray = (float[])ViewState["Acts of Subterfuge"];
            Array.Resize(ref subterfugeArray, subterfugeArray.Length + 1);

            int newIndex = assetArray.GetUpperBound(0);

            assetArray[newIndex] = assetTextBox.Text;
            ViewState["Assets"] = assetArray;

            electionArray[newIndex] = float.Parse(electionsTextBox.Text);
            ViewState["Rigged Elections"] = electionArray;

            subterfugeArray[newIndex] = float.Parse(subterfugeTextBox.Text);
            ViewState["Acts of Subterfuge"] = subterfugeArray;

            resultLabel.Text = String.Format("Total Elections Rigged: {0} <br />" +
                "Average Acts of Subterfuge per Asset: {1:N2} <br />(Last Asset you added: {2})",
                electionArray.Sum(), subterfugeArray.Average(), assetArray[newIndex]);
        }
    }
}