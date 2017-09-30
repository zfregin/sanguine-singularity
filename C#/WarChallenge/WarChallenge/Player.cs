using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarChallenge
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public List<Card> BountyWon { get; set; }
        public string Name { get; set; }

        public Player()
        {
            Hand = new List<Card>();
            BountyWon = new List<Card>();
        }
    }
}