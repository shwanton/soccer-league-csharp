using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class Printer
    {
        private List<Team> _teams;

        public Printer(List<Team> teams)
        {
            _teams = teams;
        }

        public string Print()
        {
            return _teams.Aggregate("", (acc, team) =>
            {
                var points = team.Score == 1 ? "pt" : "pts";
                var line = $"{team.Rank}. {team.Name}, {team.Score} {points}\n";
                return acc + line;
            });
        }
    }
}
