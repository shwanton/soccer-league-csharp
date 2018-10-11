using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public static class Ranker
    {
        public static List<Team> Rank(List<Team> teams)
        {
            return teams
                .Select((team, index) =>
                {
                    return new Team()
                    {
                        Name = team.Name,
                        Score = team.Score,
                        Rank = Calculate(teams, team, index),
                        GoalDiff = team.GoalDiff,
                    };
                }).ToList();
        }

        private static int Calculate(List<Team> teams, Team currentTeam, int rank)
        {
            if (rank < 1)
                return 1;

            var prevTeam = teams[rank - 1];
            return shouldIncrement(currentTeam, prevTeam) ? rank + 1 : rank;
        }
        
        private static bool shouldIncrement(Team teamA, Team teamB)
        {
            return (teamA.GoalDiff != teamB.GoalDiff || teamA.Score != teamB.GoalDiff);
        }
    }
}

