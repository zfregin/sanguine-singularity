using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarChallenge
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private Battle _battle;

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };
            _battle = new Battle(_player1, _player2);
        }

        public string Play(Random rand)
        {
            string result = "";
            Deck GameDeck = new Deck();
            List<Card> fullDeck = GameDeck.Cards;
            result += GameDeck.Deal(fullDeck, rand, _player1, _player2);
            result += "<H2> Begin Battle ...</H2>";
            for (int i = 0; i < 20; i++)
            {
                result = _battle.CardBattle(_player1, _player2);
            }

            result += getWinner();

            return result;
        }

        public string getWinner()
        {
            Player winner;
            int player1Score = _player1.Hand.Count;
            int player2Score = _player2.Hand.Count;
            if (player1Score == player2Score) return String.Format("It's a tie!!<br />Player 1: {0}<br />Player 2: {1}", player1Score.ToString(), player2Score.ToString());
            if (player1Score > player2Score) winner = _player1;
            else winner = _player2;

            return String.Format("<span style='color:red;font-weight:bolder;'>{0} wins</span><br /><span style='color:red;font-weight:bolder;'>Player 1: {1}</span><br /><span style='color:blue;font-weight:bolder;'>Player 2: {2}</span>", winner.Name, player1Score.ToString(), player2Score.ToString());
        }

    }
}