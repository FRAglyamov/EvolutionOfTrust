using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionOfTrust.Characters
{
    public class Cheater : Character
    {
        public Cheater(int id) : base(id) { }
        public override Action FirstAction => Action.Cheat;

        public override Action MakeAction(int opponentId)
        {
            return Action.Cheat;
        }
    }
}
