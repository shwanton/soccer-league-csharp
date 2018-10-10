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
            var rank = 0;
            return _teams
                .Select((team, index) =>
                {
                    rank = ScoreDidNotChange(team, index) ? rank : rank + 1;

                    return new Team()
                    {
                        Name = team.Name,
                        Score = team.Score,
                        Rank = rank,
                    };
                }).ToList();
        }

        private bool ScoreDidNotChange(Team team, int index)
        {
            return (index > 1 && team.Score == _teams[index - 1].Score);
        }
    }
}
