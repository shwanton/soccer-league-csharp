using System;
using System.Collections.Generic;

namespace League
{
    public interface ILeague
    {
        List<Team> GetTeamGameStats(List<Game> games);
        List<Team> SortTeams(List<Team> teams);
        List<Team> RankTeams(List<Team> teams);
        string PrintTeamStats(List<Team> teams);
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
            var games = _parser.LoadGames();

            return GetStats(games)
                .SortStats()
                .RankStats()
                .PrintStats();
        }

        private LeagueStats GetStats(List<Game> games)
        {
            _stats = GetTeamGameStats(games);

            return this;
        }

        private LeagueStats SortStats()
        {
            _stats = SortTeams(_stats);

            return this;
        }

        private LeagueStats RankStats()
        {
            _stats = RankTeams(_stats);

            return this;
        }

        private string PrintStats()
        {
            return PrintTeamStats(_stats);
        }

        public List<Team> GetTeamGameStats(List<Game> games)
        {
            return Calculator.GameStats(games);
        }

        public List<Team> SortTeams(List<Team> teams)
        {
            return Sorter.Sort(teams);
        }

        public List<Team> RankTeams(List<Team> teams)
        {
            return Ranker.Rank(teams);
        }

        public string PrintTeamStats(List<Team> teams)
        {
            return Printer.PrintStats(teams);
        }
    }
}
