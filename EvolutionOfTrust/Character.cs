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
        public Dictionary<int, List<Action>> OpponentsActions = new Dictionary<int, List<Action>>();
        public abstract Action FirstAction { get; }
        public abstract Action MakeAction(int opponentId);

        public Character(int id)
        {
            this.id = id;
        }
    }
}
