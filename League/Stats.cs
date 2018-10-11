using System;
using System.Collections.Generic;

namespace League
{
    public class Stats
    {
        private readonly IGameParser _parser;

        private List<Game> _games;
        private List<Team> _teams;

        public Stats(IGameParser parser)
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
        
        public Stats LoadData()
        {
            _games = _parser.LoadGames();

            return this;
        }

        public Stats CalculateStats()
        {
            _teams = new StatsCalulator(_games).Calculate();

            return this;
        }

        public Stats SortTeams()
        {
            _teams = new Sorter(_teams).Sort();

            return this;
        }

        public Stats RankTeams()
        {
            _teams = new Ranker(_teams).Rank();

            return this;
        }
    }
}
