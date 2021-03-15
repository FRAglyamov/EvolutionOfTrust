using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionOfTrust.Characters
{
    public class Cooperator : Character
    {
        public Cooperator(int id) : base(id) { }
        public override Action FirstAction => Action.Coop;

        public override Action MakeAction(int opponentId)
        {
            return Action.Coop;
        }
    }
}
