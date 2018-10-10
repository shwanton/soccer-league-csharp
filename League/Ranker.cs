using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class Ranker
    {
        private List<Team> _teams;

        public Ranker(List<Team> teams)
        {
            _teams = teams;
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
                        Rank = ScoreDidNotChange(team, index) ? index : index + 1,
                    };
                }).ToList();
        }

        private bool ScoreDidNotChange(Team team, int index)
        {
            return (index > 1 && team.Score == _teams[index - 1].Score);
        }
    }
}
