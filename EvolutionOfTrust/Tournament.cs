using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionOfTrust
{
    public class Tournament
    {
        List<Character> characters;
        int roundsAmount = 10;
        int eliminateReproduceAmount = 1;
        int mistakeChance = 5;
        bool isFirstRound = true;
        Match match = new Match();
        public void PlayTournament(List<Character> _characters)
        {
            characters = _characters;
            for (int i = 1; i <= roundsAmount; i++)
            {
                Console.WriteLine();
                PrintResults();
                PlayRound();
                Console.WriteLine();
                PrintResults();
                GeneticLikeReproduce(i);
                Console.WriteLine("\nRound " + i);
                PrintResults();
                ResetPoints();
            }
        }


        /// <summary>
        /// Удаляет персонажей с наименьшим количеством очков и генерирует на их место с наибольшим количеством за весь турнир
        /// </summary>
        private void GeneticLikeReproduce(int round) // Придумать нормальное название
        {
            characters.OrderByDescending(c => c.points);
            characters.RemoveRange(characters.Count - eliminateReproduceAmount, eliminateReproduceAmount);

            // Копируются ссылки, нужно сделать копию значений!!!
            var topCharacters = characters.Take(eliminateReproduceAmount).ToList();

            
            //List<Character> topCharacters = new List<Character>();

            //foreach (Character item in characters.Take(eliminateReproduceAmount).ToList())
            //{
            //    topCharacters.Add(new item.GetType())
            //}
            //for (int i = characters.Count - eliminateReproduceAmount; i < characters.Count; i++)
            //{
            //    topCharacters.Add(new(characters[i].GetType().BaseType()) { });
            //}


            for (int i = 0; i < topCharacters.ToList().Count; i++)
            {
                topCharacters[i].id += (characters.Count + eliminateReproduceAmount) * round;
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

        private void PlayRound()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                for (int j = i + 1; j < characters.Count; j++)
                {
                    match.Match2Characters(characters[i], characters[j], isFirstRound);
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
