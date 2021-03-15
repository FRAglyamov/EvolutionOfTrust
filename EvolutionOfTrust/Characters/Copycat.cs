using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionOfTrust.Characters
{
    public class Copycat : Character
    {
        public Copycat(int id) : base(id) { }
        public override Action FirstAction => Action.Coop;

        public override Action MakeAction(int opponentId)
        {
            return OpponentsActions[opponentId].Last();
        }
    }
}
