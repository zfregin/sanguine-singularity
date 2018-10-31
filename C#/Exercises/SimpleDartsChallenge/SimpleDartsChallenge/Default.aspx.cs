﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleDartsChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okayButton_Click(object sender, EventArgs e)
        {
            Game game = new Game("Player 1", "Player 2");
            string result = game.Play();
            resultLabel.Text = result;
        }
    }
}