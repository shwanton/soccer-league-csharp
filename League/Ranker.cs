using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class Ranker
    {
        private List<Team> _teams;

        public Ranker(List<Team> stats)
        {
            _teams = stats;
        }

        public List<Team> Rank()
        {
            return _teams
                .Select((team, index) =>
                {
                    return new Team()
                    {
                        Name = team.Name,
                        Score = team.Score,
                        Rank = CalculateRank(team, index),
                        GoalDiff = team.GoalDiff,
                    };
                }).ToList();
        }

        private int CalculateRank(Team team, int index)
        {
            if (index < 1)
                return 1;

            var prev = _teams[index - 1];
            var unchanged = (team.GoalDiff == prev.GoalDiff && team.Score == prev.Score);
            return unchanged ? index : index + 1;
        }
    }
}
