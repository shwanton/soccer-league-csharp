using System;
using System.Collections.Generic;

namespace League
{
    public class Stats
    {
        private List<Game> _games;
        private List<Team> _teams;

        public Stats(List<Game> games)
        {
            _games = games;
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


        public string PrintResults()
        {
            return new Printer(_teams).Print();
        }
    }
}
