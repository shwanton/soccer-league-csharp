using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class Sorter
    {
        private List<Team> _teams;

        public Sorter(List<Team> teams)
        {
            _teams = teams;
        }

        public List<Team> Sort()
        {
            return _teams
                .OrderByDescending(team => team.Score)
                .ThenByDescending(team => team.GoalDiff)
                .ThenBy(team => team.Name, StringComparer.Ordinal)
                .ToList();
        }
    }
}
