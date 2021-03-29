using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionOfTrust
{
    public class Tournament
    {
        List<Character> characters;
        int _roundsAmount = 10;
        int _eliminateReproduceAmount = 1;
        int _mistakeChance = 5;
        PointsSystem _pointsSystem = new PointsSystem();
        bool isFirstRound = true;
        Match match;

        public Tournament() { }
        public Tournament(int roundAmount, int eliminateReproduceAmount, int mistakeChance, PointsSystem pointsSystem)
        {
            _roundsAmount = roundAmount;
            _eliminateReproduceAmount = eliminateReproduceAmount;
            _mistakeChance = mistakeChance;
            _pointsSystem = pointsSystem;
        }

        public void PlayTournament(List<Character> _characters)
        {
            Match match = new Match(_pointsSystem);
            characters = _characters;
            for (int i = 1; i <= _roundsAmount; i++)
            {
                //Console.WriteLine();
                //PrintResults();
                PlayRound();
                //Console.WriteLine();
                //PrintResults();
                GeneticLikeReproduce(i);
                Console.WriteLine("\nRound " + i);
                PrintResults();
                ResetPoints();
            }
        }


        /// <summary>
        /// Удаляет персонажей с наименьшим количеством очков и генерирует на их место с наибольшим количеством за весь турнир
        /// </summary>
        private void GeneticLikeReproduce(int round)
        {
            characters.Sort((c1, c2) => c2.points.CompareTo(c1.points));
            characters.RemoveRange(characters.Count - _eliminateReproduceAmount, _eliminateReproduceAmount);

            var topCharacters = characters.Take(_eliminateReproduceAmount).Select(x => x.Clone()).ToList();
            for (int i = 0; i < topCharacters.ToList().Count; i++)
            {
                topCharacters[i].id += (characters.Count + _eliminateReproduceAmount) * round;
                topCharacters[i].OpponentsActions.Clear();
            }
            characters.AddRange(topCharacters);
        }

        private void ResetPoints()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].points = 0;
            }
        }

        /// <summary>
        /// Проигрывание одного раунда (одноразовое сопоставление, действие участников друг с другом)
        /// </summary>
        private void PlayRound()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                for (int j = i + 1; j < characters.Count; j++)
                {
                    match.Match2Characters(characters[i], characters[j], isFirstRound, _mistakeChance);
                }
            }
            isFirstRound = false;
        }

        private void PrintResults()
        {
            foreach (Character c in characters)
            {
                Console.WriteLine("ID: " + c.id + ", Type: " + c.GetType().Name + ", Points: " + c.points);
            }
        }
    }
}
