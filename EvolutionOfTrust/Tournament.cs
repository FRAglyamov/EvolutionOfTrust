using EvolutionOfTrust.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionOfTrust
{
    public class Tournament
    {
        private List<Character> _characters = new List<Character>();
        private int _roundsAmount;
        private int _tournamentAmount;
        private int _eliminateReproduceAmount;
        private int _mistakeChance;
        private PointsSystem _pointsSystem = new PointsSystem();
        private bool _isFirstRound = true;
        private Match _match;

        //public Tournament() { }
        /// <summary>
        /// PointSystem по умолчанию (2,3,-1,0)
        /// </summary>
        /// <param name="pointsSystem"></param>
        /// <param name="roundAmount"></param>
        /// <param name="eliminateReproduceAmount"></param>
        /// <param name="mistakeChance"></param>
        public Tournament(PointsSystem pointsSystem = default(PointsSystem), int roundAmount = 10, int tournamentAmount = 5, int eliminateReproduceAmount = 2, int mistakeChance = 5)
        {
            if (pointsSystem != null)
                _pointsSystem = pointsSystem;
            _roundsAmount = roundAmount;
            _tournamentAmount = tournamentAmount;
            _eliminateReproduceAmount = eliminateReproduceAmount;
            _mistakeChance = mistakeChance;
        }

        public void PlayTournaments(List<Character> characters, out Dictionary<int, List<Character>> tournamentLogs, bool printLogs = false)
        {
            tournamentLogs = new Dictionary<int, List<Character>>();
            _match = new Match(_pointsSystem);
            _characters = characters;
            for (int i = 1; i <= _tournamentAmount; i++)
            {
                PlayRound();
                GeneticLikeReproduce(i);
                if(printLogs)
                {
                    Console.WriteLine("\nRound " + i);
                    PrintResults();
                }    
                tournamentLogs.Add(i, _characters.Select(x => x.Clone()).ToList());
                ResetPoints();
            }
        }

        public void PrintLogsInConsole(Dictionary<int, List<Character>> tournamentLogs)
        {
            for (int i = 1; i <= _tournamentAmount; i++)
            {
                Console.WriteLine("Round " + i);
                List<Character> tmpCharacterList = tournamentLogs[i];
                foreach (Character c in tmpCharacterList)
                {
                    Console.WriteLine("ID: " + c.id + ", Type: " + c.GetType().Name + ", Points: " + c.points);
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Удаляет персонажей с наименьшим количеством очков и генерирует на их место с наибольшим количеством за весь турнир
        /// </summary>
        private void GeneticLikeReproduce(int round)
        {
            _characters.Sort((c1, c2) => c2.points.CompareTo(c1.points));
            _characters.RemoveRange(_characters.Count - _eliminateReproduceAmount, _eliminateReproduceAmount);

            var topCharacters = _characters.Take(_eliminateReproduceAmount).Select(x => x.Clone()).ToList();
            for (int i = 0; i < topCharacters.ToList().Count; i++)
            {
                topCharacters[i].id += (_characters.Count + _eliminateReproduceAmount) * round;
                topCharacters[i].OpponentsActions.Clear();
            }
            _characters.AddRange(topCharacters);
        }
        /// <summary>
        /// Сбрасывание очков до 0 у всех Character'ов
        /// </summary>
        private void ResetPoints()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].points = 0;
            }
        }

        /// <summary>
        /// Проигрывание одного раунда (одноразовое сопоставление, действие участников друг с другом)
        /// </summary>
        private void PlayRound()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                for (int j = i + 1; j < _characters.Count; j++)
                {
                    _isFirstRound = true;
                    for (int k = 0; k < _roundsAmount; k++)
                    {
                        _match.Match2Characters(_characters[i], _characters[j], _isFirstRound, _mistakeChance);
                        _isFirstRound = false;
                    }
                }
            }
        }

        private void PrintResults()
        {
            foreach (Character c in _characters)
            {
                Console.WriteLine("ID: " + c.id + ", Type: " + c.GetType().Name + ", Points: " + c.points);
            }
        }

        //public List<Character> CreateListOfCharacters(params (Type character, int amount)[] tuples)
        //{
        //    foreach (var t in tuples)
        //    {
        //        for (int i = 0; i < t.amount; i++)
        //        {
        //        }
        //    }
        //    return _characters;
        //}
    }
}
