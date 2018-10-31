using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        private Random _random;
        public int Score { get; set; }
        public bool IsDouble { get; set; }
        public bool IsTriple { get; set; }
        public bool IsInnerBullsEye { get; set; }

        public void Throw()
        {
            Score = _random.Next(0, 21);

            int multiplier = _random.Next(1, 101);
            if (multiplier > 95) IsTriple = true;
            else if (multiplier > 90) IsDouble = true;
            else if (Score == 0 && multiplier > 85) IsInnerBullsEye = true;
        }
        
        public Dart(Random random)
        {
            _random = random;
        }
    }
}
