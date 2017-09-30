using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarChallenge
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        Card[] cards = new Card[52];
        string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        public Deck()
        {
            Cards = new List<Card>();
            foreach (var val in values)
            {
                Cards.Add(new Card("Spades", val));
            }
            foreach (var val in values)
            {
                Cards.Add(new Card("Clubs", val));
            }
            foreach (var val in values)
            {
                Cards.Add(new Card("Diamonds", val));
            }
            foreach (var val in values)
            {
                Cards.Add(new Card("Hearts", val));
            }
        }

        public string Deal(List<Card> deck, Random rand, Player player1, Player player2)
        {
            string label = "<H2>Dealing Cards...</H2>";
            for (int i = deck.Count - 1; i > 0; i -= 2)
            {
                Card p1 = deck[rand.Next(i + 1)];
                player1.Hand.Add(p1);
                deck.Remove(p1);
                label += String.Format("{0} is dealt the {1}<br />", player1.Name, p1.CardName());

                Card p2 = deck[rand.Next(i)];
                player2.Hand.Add(p2);
                deck.Remove(p2);
                label += String.Format("{0} is dealt the {1}<br />", player2.Name, p2.CardName());
            }
            return label;
        }

        public List<Card> FullDeck()
        {
            {
                return Cards;
            }
        }
    }
}