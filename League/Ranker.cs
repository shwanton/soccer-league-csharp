using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public interface IIncrementRank
    {
         bool CanIncrement(Team team, Team prev);
    }

    public struct GoalScoreIncrement : IIncrementRank
    {
        public bool CanIncrement(Team team, Team prev)
        {
            return (team.GoalDiff != prev.GoalDiff || team.Score != prev.Score);
        }
    }


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
                        Rank = CalculateRank(team, index, new GoalScoreIncrement().CanIncrement),
                        GoalDiff = team.GoalDiff,
                    };
                }).ToList();
        }

        private int CalculateRank(Team team, int index, Func<Team, Team, bool> canIncrement)
        {
            if (index < 1)
                return 1;


            return canIncrement(team, _teams[index - 1]) ? index + 1 : index;
        }
    }
}
