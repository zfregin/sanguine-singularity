using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            Random rand = new Random();
            /*Player player1 = new Player();
            player1.Name = "Player 1";
            Player player2 = new Player();
            player2.Name = "Player 2";*/

            Game game = new Game("Player 1", "Player 2");
            resultLabel.Text = game.Play(rand);


            //resultLabel.Text = GameDeck.Deal(fullDeck, rand, player1, player2);
        }
    }
}