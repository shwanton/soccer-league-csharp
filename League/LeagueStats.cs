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
        
        public string PrintResults()
        {
            return new Printer(_teams).Print();
        }
        
        public LeagueStats LoadData()
        {
            _games = _parser.LoadGames();

            return this;
        }

        public LeagueStats CalculateStats()
        {
            _teams = new StatsCalulator(_games).Calculate();

            return this;
        }

        public LeagueStats SortTeams()
        {
            _teams = new Sorter(_teams).Sort();

            return this;
        }

        public LeagueStats RankTeams()
        {
            _teams = new Ranker(_teams).Rank();

            return this;
        }
    }
}
