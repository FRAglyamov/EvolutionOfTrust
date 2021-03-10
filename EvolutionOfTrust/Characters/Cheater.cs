using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionOfTrust.Characters
{
    class Cheater : Character
    {
        public override Action FirstAction => Action.Cheat;

        public override Action MakeAction(string opponentId)
        {
            return Action.Cheat;
        }
    }
}
