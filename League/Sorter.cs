using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public static class Sorter
    {
        public static List<Team> Sort(List<Team> teams)
        {
            return teams
                .OrderByDescending(team => team.Score)
                .ThenByDescending(team => team.GoalDiff)
                .ThenBy(team => team.Name, StringComparer.Ordinal)
                .ToList();
        }
    }
}
