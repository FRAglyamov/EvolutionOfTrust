

namespace ConsoleAppForTesting
{
    /// <summary>
    /// Пример своего класса, который обманывает при каждом третьем взаимодействии
    /// </summary>
    class MultipleOf3Cheat : EvolutionOfTrust.Character
    {
        public MultipleOf3Cheat(int id) : base(id) { }
        public override EvolutionOfTrust.Action FirstAction => EvolutionOfTrust.Action.Coop;
        public override EvolutionOfTrust.Action MakeAction(int opponentId)
        {
            if (OpponentsActions[opponentId].Count / 3 == 0)
            {
                return EvolutionOfTrust.Action.Cheat;
            }
            else
            {
                return EvolutionOfTrust.Action.Coop;
            }
        }
    }
}
