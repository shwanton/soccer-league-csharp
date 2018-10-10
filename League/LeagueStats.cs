using System;

namespace League
{
    public class LeagueStats
    {
        private readonly IGameParser _parser;

        public LeagueStats(IGameParser parser)
        {
            _parser = parser;
        }

        public string GetSeason()
        {
            var data = _parser.LoadGames();

            var stats = new StatsCalulator(data).Calculate();
            var sorted = new Sorter(stats).Sort();
            var ranked = new Ranker(sorted).Rank();

            return new Printer(ranked).Print();
        }
    }
}
