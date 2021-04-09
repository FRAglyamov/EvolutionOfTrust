using System.Linq;

namespace EvolutionOfTrust.Characters
{
    /// <summary>
    /// Имитатор, повторяет прошлое действие оппонента, начинает с кооперации
    /// </summary>
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
