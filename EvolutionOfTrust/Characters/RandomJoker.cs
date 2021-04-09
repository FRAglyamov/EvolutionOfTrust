

namespace EvolutionOfTrust.Characters
{
    /// <summary>
    /// Шут, действие которого воля случая
    /// </summary>
    public class RandomJoker : Character
    {
        System.Random random = new System.Random();
        public RandomJoker(int id) : base(id) { }
        public override Action FirstAction => MakeAction(0);

        public override Action MakeAction(int opponentId)
        {
            return (Action)random.Next(2);
        }
    }
}
