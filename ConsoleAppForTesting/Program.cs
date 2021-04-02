using System;
using System.Collections.Generic;
using EvolutionOfTrust;
using EvolutionOfTrust.Characters;

namespace ConsoleAppForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();

            for (int i = 0; i < 12; i++)
            {
                characters.Add(new Cheater(characters.Count));
            }
            for (int i = 0; i < 13; i++)
            {
                characters.Add(new Copycat(characters.Count));
            }
            for (int i = 0; i < 0; i++)
            {
                characters.Add(new Cooperator(characters.Count));
            }
            for (int i = 0; i < 0; i++)
            {
                characters.Add(new Grudger(characters.Count));
            }
            for (int i = 0; i < 0; i++)
            {
                characters.Add(new RandomJoker(characters.Count));
            }

            Tournament tournament = new Tournament(mistakeChance: 0, eliminateReproduceAmount: 5);
            //Dictionary<int, List<Character>> tournamentLogs;
            tournament.PlayTournaments(characters, out _, printLogs: true);
            //tournament.PrintLogsInConsole(tournamentLogs);
            Console.ReadKey();
        }
    }
}
