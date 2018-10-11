using System;
using System.Collections.Generic;

namespace League
{
    public interface ILeague
    {
        ILeague SortTeams();
        ILeague RankTeams();
        string PrintTeamStats();
    }

    public class LeagueStats : ILeague
    {
        private readonly IGameParser _parser;
        private List<Team> _stats;

        public LeagueStats(IGameParser parser)
        {
            _parser = parser;
        }

        public string GetSeason()
        {
            _stats = GetTeamStats();

            return SortTeams().RankTeams().PrintTeamStats();
        }

        public ILeague SortTeams()
        {
            _stats = Sorter.Sort(_stats);

            return this;
        }

        public ILeague RankTeams()
        {
            _stats = Ranker.Rank(_stats);

            return this;
        }

        public string PrintTeamStats()
        {
            return Printer.PrintStats(_stats);
        }

        private List<Team> GetTeamStats()
        {
            var games = _parser.LoadGames();
            return Calculator.GameStats(games);
        }
    }
}
