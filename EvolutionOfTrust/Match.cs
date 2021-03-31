using System;
using System.Collections.Generic;

namespace EvolutionOfTrust
{
    internal class Match
    {
        private PointsSystem _pointsSystem;
        internal Match(PointsSystem pointsSystem)
        {
            _pointsSystem = pointsSystem;
        }
        private Random _random = new Random();

        public void Match2Characters(Character c1, Character c2, bool isFirstRound, int mistakeChance)
        {
            Action c1Action, c2Action;
            if (isFirstRound || c1.OpponentsActions.ContainsKey(c2.id) == false)
            {
                c1Action = c1.FirstAction;
                c2Action = c2.FirstAction;
            }
            else
            {
                c1Action = c1.MakeAction(c2.id);
                c2Action = c2.MakeAction(c1.id);
            }

            MistakeRoll(mistakeChance, ref c1Action);
            MistakeRoll(mistakeChance, ref c2Action);
            MemorizeOpponentAction(c1, c2, c2Action);
            MemorizeOpponentAction(c2, c1, c1Action);
            switch ((c1Action, c2Action))
            {
                case (Action.Coop, Action.Coop):
                    CoopBothResult(c1, c2);
                    break;
                case (Action.Cheat, Action.Cheat):
                    CheatBothResult(c1, c2);
                    break;
                case (Action.Coop, Action.Cheat):
                    CoopCheatResult(c1, c2);
                    break;
                case (Action.Cheat, Action.Coop):
                    CoopCheatResult(c2, c1);
                    break;
                default:
                    break;
            }
        }

        private void MistakeRoll(int mistakeChance, ref Action c1Action)
        {
            if (mistakeChance > _random.Next(1, 101))
            {
                Console.WriteLine("Mistake roll!");
                c1Action += 1;
            }
        }

        private static void MemorizeOpponentAction(Character character, Character opponent, Action opponentAction)
        {
            if (!character.OpponentsActions.ContainsKey(opponent.id))
                character.OpponentsActions.Add(opponent.id, new List<Action>());
            character.OpponentsActions[opponent.id].Add(opponentAction);
        }

        private void CoopBothResult(Character c1, Character c2)
        {
            c1.points += _pointsSystem.CoopPoints;
            c2.points += _pointsSystem.CoopPoints;
        }
        private void CheatBothResult(Character c1, Character c2)
        {
            c1.points += _pointsSystem.CheatBothPoints;
            c2.points += _pointsSystem.CheatBothPoints;
        }
        private void CoopCheatResult(Character coopCharacter, Character cheatCharacter)
        {
            coopCharacter.points += _pointsSystem.CheatedPoints;
            cheatCharacter.points += _pointsSystem.CheatPoints;
        }
    }
}
