using System;
using System.Collections.Generic;

namespace League
{
    public class LeagueStats
    {
        private readonly IGameParser _parser;

        private List<Game> _games;
        private List<Team> _rawStats;
        private List<Team> _sortedStats;
        private List<Team> _rankedStats;

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
            _rawStats = Calculator.GameStats(_games);

            return this;
        }

        public LeagueStats SortTeams()
        {
            _sortedStats = Sorter.Sort(_rawStats);

            return this;
        }

        public LeagueStats RankTeams()
        {
            _rankedStats = Ranker.Rank(_sortedStats);

            return this;
        }
        
        public string PrintResults()
        {
            return Printer.PrintStats(_rankedStats);
        }
    }
}
