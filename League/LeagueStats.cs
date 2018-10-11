using System;
using System.Collections.Generic;

namespace League
{
    public class LeagueStats
    {
        private readonly IGameParser _parser;

        private List<Game> _games;
        private List<Team> _teams;

        public LeagueStats(IGameParser parser)
        {
            _parser = parser;
        }

        public string GetSeason()
        {
            return LoadData()
                .CalculateStats()
                .SortTeams()
                .RankTeams()
                .PrintResults();
        }
        
        public LeagueStats LoadData()
        {
            _games = _parser.LoadGames();

            return this;
        }

        public LeagueStats CalculateStats()
        {
            _teams = Calculator.GameStats(_games);

            return this;
        }

        public LeagueStats SortTeams()
        {
            _teams = Sorter.Sort(_teams);

            return this;
        }

        public LeagueStats RankTeams()
        {
            _teams = Ranker.Rank(_teams);

            return this;
        }
        
        public string PrintResults()
        {
            return Printer.PrintStats(_teams);
        }
    }
}
