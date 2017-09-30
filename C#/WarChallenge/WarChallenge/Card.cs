using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarChallenge
{
    public class Card
    {
        private string _suit;
        private string _cardValue;

        public Card()
        {
        }

        public Card(string suit, string cardValue)
        {
            _suit = suit;
            _cardValue = cardValue;
        }

        public string CardName()
        {
            return String.Format("{0} of {1}", _cardValue, _suit);
        }

        public int cardRank()
        {
            int value = 0;

            switch (this._cardValue)
            {
                case "Jack":
                    value = 11;
                    break;
                case "Queen":
                    value = 12;
                    break;
                case "King":
                    value = 13;
                    break;
                case "Ace":
                    value = 14;
                    break;

                default:
                    value = int.Parse(this._cardValue);
                    break;
            }
            return value;
        }
    }
}