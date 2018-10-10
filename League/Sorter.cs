using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class Sorter
    {
        private List<Team> _stats;

        public Sorter(List<Team> stats)
        {
            _stats = stats;
        }

        public List<Team> Sort()
        {
            return _stats
                .OrderByDescending(team => team.Score)
                .ThenBy(team => team.Name, StringComparer.Ordinal)
                .ToList();
        }
    }
}
