using System;
using System.Collections.Generic;

namespace EvolutionOfTrust
{
    /// <summary>
    /// Класс матча (одноразового взаимодействия) Character'ов друг с другом
    /// </summary>
    internal class Match
    {
        private PointsSystem _pointsSystem;
        internal Match(PointsSystem pointsSystem)
        {
            _pointsSystem = pointsSystem;
        }
        private Random _random = new Random();

        /// <summary>
        /// Проигрывание одного раунда между двумя Character'ами
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="isFirstRound"></param>
        /// <param name="mistakeChance"></param>
        public void Match2Characters(Character c1, Character c2, bool isFirstRound, int mistakeChance)
        {
            Action c1Action, c2Action;
            if (isFirstRound || !c1.OpponentsActions.ContainsKey(c2.id) || !c2.OpponentsActions.ContainsKey(c1.id))
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

        /// <summary>
        /// Бросок "кубика" на ошибку
        /// </summary>
        /// <param name="mistakeChance"></param>
        /// <param name="c1Action"></param>
        private void MistakeRoll(int mistakeChance, ref Action c1Action)
        {
            if (mistakeChance > _random.Next(1, 101))
            {
                c1Action += 1;
            }
        }

        /// <summary>
        /// Запись/запоминание действия оппонента
        /// </summary>
        /// <param name="character"></param>
        /// <param name="opponent"></param>
        /// <param name="opponentAction"></param>
        private static void MemorizeOpponentAction(Character character, Character opponent, Action opponentAction)
        {
            if (!character.OpponentsActions.ContainsKey(opponent.id))
                character.OpponentsActions.Add(opponent.id, new List<Action>());
            character.OpponentsActions[opponent.id].Add(opponentAction);
        }

        /// <summary>
        /// Изменение очков Character'ов при ситуации Coop - Coop
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        private void CoopBothResult(Character c1, Character c2)
        {
            c1.points += _pointsSystem.CoopPoints;
            c2.points += _pointsSystem.CoopPoints;
        }

        /// <summary>
        /// Изменение очков Character'ов при ситуации Cheat - Cheat
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        private void CheatBothResult(Character c1, Character c2)
        {
            c1.points += _pointsSystem.CheatBothPoints;
            c2.points += _pointsSystem.CheatBothPoints;
        }

        /// <summary>
        /// Изменение очков Character'ов при ситуации Coop - Cheat
        /// </summary>
        /// <param name="coopCharacter"></param>
        /// <param name="cheatCharacter"></param>
        private void CoopCheatResult(Character coopCharacter, Character cheatCharacter)
        {
            coopCharacter.points += _pointsSystem.CheatedPoints;
            cheatCharacter.points += _pointsSystem.CheatPoints;
        }
    }
}
