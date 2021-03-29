using System;
using System.Collections.Generic;

namespace EvolutionOfTrust
{
    public class PointsSystem
    {
        public int CoopPoints { get; private set; }
        public int CheatPoints { get; private set; }
        public int CheatedPoints { get; private set; }
        public int CheatBothPoints { get; private set; }
        public PointsSystem(int coopPoints = 2, int cheatPoints = 3, int cheatedPoints = -1, int cheatBothPoints = 0)
        {
            CoopPoints = coopPoints;
            CheatPoints = cheatPoints;
            CheatedPoints = cheatedPoints;
            CheatBothPoints = cheatBothPoints;
        }
    }
}
