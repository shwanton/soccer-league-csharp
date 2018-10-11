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
                        Rank = RankCalulator.Calculate(teams, team, index),
                        GoalDiff = team.GoalDiff,
                    };
                }).ToList();
        }
    }

    public static class RankCalulator
    {
        public static int Calculate(List<Team> teams, Team team, int index)
        {
            if (index < 1)
                return 1;

            Func<Team, Team, bool> canIncrement = new GoalDiffRule().CanIncrement;

            return canIncrement(team, teams[index - 1]) ? index + 1 : index;
        }
    }

    public interface IRankRule
    {
        bool CanIncrement(Team team, Team prev);
    }

    public struct GoalDiffRule : IRankRule
    {
        public bool CanIncrement(Team team, Team prev)
        {
            return (team.GoalDiff != prev.GoalDiff || team.Score != prev.Score);
        }
    }

}

