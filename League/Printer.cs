using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public static class Printer
    {
        public static string PrintStats(List<Team> teams)
        {
            return teams.Aggregate("", (acc, team) =>
            {
                var points = team.Score == 1 ? "pt" : "pts";
                var line = $"{team.Rank}. {team.Name}, {team.Score} {points}, GD: {team.GoalDiff}\n";
                return acc + line;
            });
        }
    }
}
