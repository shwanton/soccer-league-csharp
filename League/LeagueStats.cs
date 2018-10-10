using System;
using System.Collections.Generic;

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

            var stats = new Stats(data);

            return stats
                .CalculateStats()
                .SortTeams()
                .RankTeams()
                .PrintResults();
        }
    }
}
