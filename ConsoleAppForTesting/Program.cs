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
            characters.Add(new Cheater(characters.Count));
            characters.Add(new Cheater(characters.Count));
            characters.Add(new Copycat(characters.Count));
            characters.Add(new Copycat(characters.Count));
            characters.Add(new Copycat(characters.Count));
            characters.Add(new Copycat(characters.Count));
            characters.Add(new Copycat(characters.Count));

            Tournament tournament = new Tournament();
            Dictionary<int, List<Character>> tournamentLogs;
            tournament.PlayTournament(characters, out tournamentLogs);
            tournament.PrintLogsInConsole(tournamentLogs);
            Console.ReadKey();
        }
    }
}
