

namespace EvolutionOfTrust.Characters
{
    /// <summary>
    /// Злопамятный, кооперируется до тех пор, пока хоть раз не обманут, потом всегда обманывает
    /// </summary>
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
