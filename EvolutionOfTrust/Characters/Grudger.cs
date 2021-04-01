

namespace EvolutionOfTrust.Characters
{
    public class Grudger : Character
    {
        public Grudger(int id) : base(id) { }
        public override Action FirstAction => Action.Coop;

        public override Action MakeAction(int opponentId)
        {
            return OpponentsActions[opponentId].Exists(x => x == Action.Cheat) ? Action.Cheat : Action.Coop;
        }
    }
}
