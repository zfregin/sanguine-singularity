using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace SimpleDartsChallenge
{
    public class Score
    {
        public static void ScoreDart(Player player, Dart dart)
        {
            int dartPoints = 0;
            if (dart.Score == 0 && dart.IsInnerBullsEye) dartPoints = 50;
            else if (dart.Score == 0 && !dart.IsInnerBullsEye) dartPoints = 25;
            else if (dart.IsTriple) dartPoints = dart.Score * 3;
            else if (dart.IsDouble) dartPoints = dart.Score * 2;
            else dartPoints = dart.Score;
            player.Score += dartPoints;
        }
    }
}