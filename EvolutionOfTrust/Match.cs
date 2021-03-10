using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionOfTrust
{
    public class Match
    {
        List<Character> characters;
        int roundsAmount = 10;
        int eliminateReproduceAmount = 5;
        int mistakeChance = 5;
        bool isFirstRound = true;

        void PlayTournament()
        {
            for (int i = 0; i < roundsAmount; i++)
            {
                PlayRound();
            }
            GeneticLikeReproduce();
        }


        /// <summary>
        /// Удаляет персонажей с наименьшим количеством очков и генерирует на их место с наибольшим количеством за весь турнир
        /// </summary>
        private void GeneticLikeReproduce() // Придумать нормальное название
        {
            characters.OrderByDescending(c => c.points);
            characters.RemoveRange(characters.Count - eliminateReproduceAmount - 1, eliminateReproduceAmount);
            var topCharacters = characters.Take(eliminateReproduceAmount);
            characters.AddRange(topCharacters);
        }

        private void PlayRound()
        {
            foreach (Character c1 in characters)
            {
                foreach (Character c2 in characters)
                {
                    if (c1 == c2)
                        continue;
                    Match2Characters(c1, c2);
                }
            }
        }



        void Match2Characters(Character c1, Character c2) // Добавить вероятность ошибки
        {
            Action c1Action, c2Action;
            if (isFirstRound)
            {
                c1Action = c1.FirstAction;
                c2Action = c2.FirstAction;
                isFirstRound = false;
            }
            else
            {
                c1Action = c1.MakeAction("");
                c2Action = c2.MakeAction("");
            }
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
