using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionOfTrust
{
    public enum Action
    {
        Coop,
        Cheat
    }

    public abstract class Character
    {
        public int id;
        public int points;
        public Dictionary<string, List<Action>> OpponentsActions = new Dictionary<string, List<Action>>();
        public abstract Action FirstAction { get; }
        public abstract Action MakeAction(string opponentId);
    }
}
