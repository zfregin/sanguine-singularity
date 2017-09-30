using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarChallenge
{
    public class Battle
    {
        public List<Card> _bounty;
        private string battleResult = "";

        public Battle(Player player1, Player player2)
        {

        }

        public string CardBattle(Player player1, Player player2)
        {
            _bounty = new List<Card>();
            Card player1Card = takeCard(player1);
            Card player2Card = takeCard(player2);

            Player winner = compareCards(player1, player2, player1Card, player2Card);
            battleResult += BattleResults(winner, _bounty);
            return battleResult;
        }

        private Card takeCard(Player player)
        {
            Card card = player.Hand.ElementAt(0);
            player.Hand.Remove(card);
            _bounty.Add(card);
            return card;
        }

        private Player compareCards(Player player1, Player player2, Card p1Card, Card p2Card)
        {
            battleResult += String.Format("Battle Cards: {0} versus {1}<br />", p1Card.CardName(), p2Card.CardName());
            if (p1Card.cardRank() > p2Card.cardRank())
            {
                player1.Hand.AddRange(_bounty);
                return player1;
            }
            if (p1Card.cardRank() == p2Card.cardRank())
            {
                battleResult += "***********WAR***********<br /><br />";
                return War(player1, player2);
            }
            else
            {
                player2.Hand.AddRange(_bounty);
                return player2;
            }
        }

        private Player War(Player player1, Player player2)
        {
            Card p1b1Card = takeCard(player1);
            Card p1b2Card = takeCard(player1);
            Card p1b3Card = takeCard(player1);
            Card p2b1Card = takeCard(player2);
            Card p2b2Card = takeCard(player2);
            Card p2b3Card = takeCard(player2);

            Player winner = compareCards(player1, player2, p1b3Card, p2b3Card);
            return winner;
        }

        private string bountyString (List<Card> bounty)
        {
            string bountyList = "";
            foreach (var card in bounty)
            {
                bountyList += "&nbsp;&nbsp;" + card.CardName() + "<br />";
            }
            return bountyList;
        }

        public string BattleResults(Player winner, List<Card> bounty)
        {
            return String.Format("Bounty...<br />{0}<br /><b>{1} Wins!</b><br /><br />", bountyString(_bounty), winner.Name);
        }
    }
}