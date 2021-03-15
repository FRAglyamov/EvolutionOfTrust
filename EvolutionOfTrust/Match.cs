using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionOfTrust
{
    internal class Match
    {
        public void Match2Characters(Character c1, Character c2, bool isFirstRound) // Добавить вероятность ошибки
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

        private static void MemorizeOpponentAction(Character character, Character opponent, Action opponentAction)
        {
            if (!character.OpponentsActions.ContainsKey(opponent.id))
                character.OpponentsActions.Add(opponent.id, new List<Action>());
            character.OpponentsActions[opponent.id].Add(opponentAction);
        }

        void CoopBothResult(Character c1, Character c2)
        {
            c1.points += 2; // Заменить 2 на переменную
            c2.points += 2;
        }
        void CheatBothResult(Character c1, Character c2)
        {
            // Добавить логике с переменными, пока ничего
        }
        void CoopCheatResult(Character coopCharacter, Character cheatCharacter)
        {
            coopCharacter.points -= 1; // Заменить на переменные
            cheatCharacter.points += 3;
        }
    }
}
