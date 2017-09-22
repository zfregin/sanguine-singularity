using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasinoChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        // Initialize random value
        Random random = new Random();
        // Initialize player's starting money value
        float playerBank = 100;

        protected void Page_Load(object sender, EventArgs e)
        {
            setReels();
            if (!Page.IsPostBack)
            {
                ViewState.Add("Player's Money", playerBank);
            }
            moneyLabel.Text = string.Format("Player's Money: {0:C}", ViewState["Player's Money"]);
        }

        private string spinReel()
        {
            // Create array of images to randomly select
            string[] images = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermelon" };
            // Select a random image from the array
            return images[random.Next(11)];
        }

        private string[] setReels()
        {
            // Create an array to hold the spin results
            string[] reelVals = new string[] { spinReel(), spinReel(), spinReel() };
            // Sets each image control to random image
            reel1.ImageUrl = reelVals[0] + ".png";
            reel2.ImageUrl = reelVals[1] + ".png";
            reel3.ImageUrl = reelVals[2] + ".png";
            return reelVals;
        }

        private bool checkBAR(string[] reelValues)
        {
            // Checks if BAR is one of the reels
            if (reelValues[0] == "Bar"
                | reelValues[1] == "Bar"
                | reelValues[2] == "Bar")
                return true;
            else return false;
        }

        private bool check7s(string[] reelValues)
        {
            // Checks if 3 7's were spun
            if (reelValues[0] == "Seven"
                && reelValues[1] == "Seven"
                && reelValues[2] == "Seven")
                return true;
            else return false;
        }

        private int countCherries(string[] reelValues)
        {
            // Counts the number of cherries spun
            int cherryCount = 0;
            for (int i = 0; i < reelValues.Length; i++)
            {
                if (reelValues[i] == "Cherry") cherryCount++;
            }
            return cherryCount;
        }

        private int cherryMultiplier(int cherryCount)
        {
            // Sets a losing multiplier by default
            int cherryMult = -1;
            // Sets 4x multiplier for 3 cherries spun
            if (cherryCount == 3) cherryMult = 4;
            // Sets 3x multiplier for 2 cherries spun
            else if (cherryCount == 2) cherryMult = 3;
            // Sets 4x multiplier for 1 cherry spun
            else if (cherryCount == 1) cherryMult = 2;
            return cherryMult;
        }

        private float getMultiplier(bool barResult, bool jackpot, int cherryMultiplier)
        {
            // Sets losing multiplier by default
            float multiplier = -1;
            // If BAR spun, you lose
            if (barResult == true) return multiplier;
            // If 3 7's spun, jackpot 100x multiplier set
            else if (jackpot == true)
            {
                multiplier = 100;
                return multiplier;
            }
            // If neither BAR nor 3 7's spun, set to cherry multiplier
            else multiplier = cherryMultiplier;
            return multiplier;
        }

        private bool tryGetWinnings(float multiplier, out float winnings)
        {
            winnings = 0;
            float bet = 0;
            // Try to parse textbox to float, if unable to ignore
            if (!float.TryParse(betTextBox.Text.Trim(), out bet)) return false;
            // Multiply bet by multiplier to determine winnings
            winnings = bet * multiplier;
            return true;
        }

        private void getResults(float winnings)
        {
            if (winnings > 0)
            {
                // Display winning results to player
                resultLabel.Text = string.Format("You bet {0:C} and won {1:C}!", float.Parse(betTextBox.Text.Trim()), winnings);
            }
            else
            {
                // Set winning to absolute value (so that currency format displays without parenthesis around value)
                float lost = Math.Abs(winnings);
                // Display losing results to player
                resultLabel.Text = string.Format("Sorry, you lost {0:C}. Better luck next time", lost);
            }
        }

        private void updateBank(float winnings)
        {
            // Update playerBank to previous ViewState value
            playerBank = (float)ViewState["Player's Money"];
            // Update playerBank with winnings
            playerBank += winnings;
            // Store updated playerBank back to ViewState
            ViewState["Player's Money"] = playerBank;
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            // Store reel values
            string[] reelValues = setReels();
            // Store multiplier value
            float multiplier = getMultiplier(checkBAR(reelValues), check7s(reelValues), cherryMultiplier(countCherries(reelValues)));
            float winnings = 0;
            if (!tryGetWinnings(multiplier, out winnings)) return;
            getResults(winnings);
            updateBank(winnings);
            // Display updated value of Player's Money
            moneyLabel.Text = string.Format("Player's Money: {0:C}", ViewState["Player's Money"]);
        }
    }
}