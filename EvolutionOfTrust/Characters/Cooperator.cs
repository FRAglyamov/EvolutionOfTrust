

namespace EvolutionOfTrust.Characters
{
    /// <summary>
    /// Наивный, всегда пытаеться скооперироваться с оппонентом
    /// </summary>
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
