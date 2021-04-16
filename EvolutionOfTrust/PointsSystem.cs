using System;

namespace EvolutionOfTrust
{
    /// <summary>
    /// Система изменения очков при взаимодействии Character'ов
    /// </summary>
    public class PointsSystem
    {
        public int CoopPoints { get; set; }
        public int CheatPoints { get; set; }
        public int CheatedPoints { get; set; }
        public int CheatBothPoints { get; set; }
        public PointsSystem(int coopPoints = 2, int cheatPoints = 3, int cheatedPoints = -1, int cheatBothPoints = 0)
        {
            CoopPoints = coopPoints;
            CheatPoints = cheatPoints;
            CheatedPoints = cheatedPoints;
            CheatBothPoints = cheatBothPoints;
        }
        public string AsString { get { return ToString(); } }

        public override string ToString()
        {
            return String.Format("Coop: {0}; Cheat: {1}; Cheated: {2}; CheatedBoth: {3}", this.CoopPoints, this.CheatPoints, this.CheatedPoints, this.CheatBothPoints);
        }
    }
}
