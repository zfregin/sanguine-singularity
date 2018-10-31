using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace SimpleDartsChallenge
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private Random _random;

        public string Play()
        {
            while (_player1.Score < 300 && _player2.Score < 300)
            {
                playerTurn(_player1);
                playerTurn(_player2);
                
            }
            return displayResults();
        }

        public void playerTurn(Player playerName)
        {
            for (int i = 0; i < 3; i++)
            {
                Dart dart = new Dart(_random);
                dart.Throw();
                Score.ScoreDart(playerName, dart);
            }
        }

        public string displayResults()
        {
            string result = String.Format("{0}: {1}<br />{2}: {3}<br />",_player1.Name, _player1.Score, _player2.Name, _player2.Score);
            return result += "Winner: " + (_player1.Score > _player2.Score ? _player1.Name : _player2.Name);
        }

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player();
            _player1.Name = player1Name;

            _player2 = new Player();
            _player2.Name = player2Name;

            _random = new Random();
        }
    }
}