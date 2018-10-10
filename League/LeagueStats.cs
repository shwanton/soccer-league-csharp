using System;

namespace League
{
    public class LeagueStats
    {
        private FileLoader _loader;

        public LeagueStats(FileLoader loader)
        {
            _loader = loader;
        }

        public string GetSeason()
        {
            var data = _loader.LoadData();
            var parsed = new GameParser(data).Parse();
            var stats = new StatsCalulator(parsed).Calculate();
            var sorted = new Sorter(stats).Sort();
            var ranked = new Ranker(sorted).Rank();
            return new Printer(ranked).Print();
        }
    }
}
