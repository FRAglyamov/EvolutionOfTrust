using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionOfTrust.Characters
{
    public class Copycat : Character
    {
        public override Action FirstAction => Action.Coop;

        public override Action MakeAction(string opponentId)
        {
            return OpponentsActions[opponentId][-1];
        }
    }
}
